using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySqlConnector;


namespace GeoApp
{
    public class Repository : IRepository
    {
        List<Sample> dataList = new List<Sample>();
        MySqlConnection conn = new MySqlConnection();

        public Repository(MySqlConnection conn)
        {
            this.conn = conn;
            dataList = RetrieveAllSamples();
        }//end constructor

        /*
         * @param sample to be added
         * @return true if successful, false if not
         * This method sends this sample to the database to be added with image. 
         * This assumes we know the sample id, need to next implement it without id created.
         */
        public bool AddNewSample(Sample sample)
        {
            bool result = true;

            //send sample to db
            MySqlCommand command = conn.CreateCommand();
            command.Parameters.AddWithValue("@sample_id" , sample.Id);
            command.Parameters.AddWithValue("@name", sample.Name);
            command.Parameters.AddWithValue("@type", sample.SampleType);
            command.Parameters.AddWithValue("@geologic_age", sample.GeologicAge);
            command.Parameters.AddWithValue("@city", sample.City);
            command.Parameters.AddWithValue("@state", sample.State);
            command.Parameters.AddWithValue("@country", sample.Country);
            command.Parameters.AddWithValue("@latitude", sample.Latitude);
            command.Parameters.AddWithValue("@longitude", sample.Longtitude);

            command.CommandText = "INSERT INTO Samples(sample_id, name, type, geologic_age, city, " +
                                    "state, country, latitude, longitude) VALUES(@sample_id, @name, @type, " +
                                    "@geologic_age, @city, @state, @country, @latitude, @longitude);";

            if (command.ExecuteNonQuery() < 1)
                result = false;
            

            //send images to database
            foreach (List<Byte> currListBytes in sample.Images)
            {
                command = conn.CreateCommand();
                command.Parameters.AddWithValue("@sample_id", sample.Id);
                command.Parameters.AddWithValue("@image", currListBytes);

                command.CommandText = "INSERT INTO Images(sample_id, image) VALUES (@sample_id, @image);";

                if (command.ExecuteNonQuery() < 1)
                    result = false;
            }

            return result;
        }

        /*
         * @param id of sample to be retrieved
         * @return the sample class instance with corresponding ID
         * This method gets a sample by id from the database by assembling all associated images
         * and creating a sample class and returning that class.
         */
        public Sample RetrieveSampleById(int id)
        {
            Sample sample = new Sample();
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.Parameters.AddWithValue("@id", id);

            //first get all images associated to Sample ID
            command.CommandText = "SELECT images FROM Images WHERE sample_id = @id;";
            DataTable data = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(data);

            List<List<Byte>> images = new List<List<byte>>();
            if (data != null)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    images.Add(data.Rows[i].Field<List<Byte>>("image"));
                }
            }

            //get the sample id, if exists poop
            command.CommandText = "SELECT * FROM Samples WHERE sample_id = @id;";
            data = new DataTable();
            adapter = new MySqlDataAdapter(command);
            adapter.Fill(data);

            if (data != null)
            {

                sample = new Sample(data.Rows[0].Field<int>("sample_id"),
                                               data.Rows[0].Field<String>("name"),
                                               data.Rows[0].Field<String>("type"),
                                               data.Rows[0].Field<String>("locationDescription"),
                                               data.Rows[0].Field<String>("geologic_age"),
                                               data.Rows[0].Field<String>("city"),
                                               data.Rows[0].Field<String>("state"),
                                               data.Rows[0].Field<String>("country"),
                                               data.Rows[0].Field<Double>("latitude"),
                                               data.Rows[0].Field<Double>("longitude"));
                if (images.Count != 0)
                    sample.Images = images;
            }

            return sample;
        }
        /*
         * @param the id of the issue to be deleted
         * @return true if successful, false if not
         * This method deletes an issue from the database with the passed in id. 
         */
        public bool DeleteIssueById(int id)
        {
            MySqlCommand command = conn.CreateCommand();
            command.Parameters.AddWithValue("@id", id);

            command.CommandText = "DELETE FROM Issues WHERE issue_id = @id;";

            if (command.ExecuteNonQuery() < 1)
            {
                return false;
            }
            else
                return true;
        }

        /*
         * @param id of sample to be deleted
         * @return true if delete successful, false if not
         */
        public bool DeleteSampleById(int id)
        {
            MySqlCommand command = conn.CreateCommand();
            command.Parameters.AddWithValue("@id", id);

            command.CommandText = "DELETE FROM Samples WHERE sample_id = @id;";

            if (command.ExecuteNonQuery() < 1)
            {
                return false;
            }
            else
                return true;
        }

        public bool EditSampleById(Sample sample)
        {
            throw new NotImplementedException();
        }

        /*
         * @return List of all issues, empty list if no issues in DB
         * This method gets issues from the database and converts them into
         * a list of returned issues.  
         */
        public List<Issue> RetrieveAllIssues()
        {
            List<Issue> result = new List<Issue>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "Select * From Issues;";
            DataTable data = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Issue currIssue = new Issue(data.Rows[i].Field<int>("issue_id"),
                                            data.Rows[i].Field<String>("description"),
                                            data.Rows[i].Field<DateTime>("date"),
                                            data.Rows[i].Field<int>("sample_id"),
                                            data.Rows[i].Field<String>("issue_type"));
                result.Add(currIssue);
            }

            return result;
        }

        public List<Sample> RetrieveAllSamples()
        {
            return new List<Sample>();
        }

        
    }
}