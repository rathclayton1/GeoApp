using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;


namespace GeoApp
{
    public class Repository : IRepository
    {
        List<Sample> _dataList = new List<Sample>();
        MySqlConnection _conn = new MySqlConnection();
        public Repository(MySqlConnection conn)
        {
            this._conn = conn;
            _dataList = RetrieveAllSamples();
        }

        /*
         * @param Sample to be added
         * @return True if successful, false if not
         * This method sends this sample to the database to be added with image. 
         * This assumes we know the sample id, need to next implement it without id created.
         */
        public bool AddNewSample(Sample sample)
        {
            bool result = true;

            //Send sample to db
            MySqlCommand command = _conn.CreateCommand();
            command.Parameters.AddWithValue("@name", sample.Name);
            command.Parameters.AddWithValue("@type", sample.SampleType);
            command.Parameters.AddWithValue("@geologic_age", sample.GeologicAge);
            command.Parameters.AddWithValue("@city", sample.City);
            command.Parameters.AddWithValue("@state", sample.State);
            command.Parameters.AddWithValue("@country", sample.Country);
            command.Parameters.AddWithValue("@latitude", sample.Latitude);
            command.Parameters.AddWithValue("@longitude", sample.Longtitude);
            command.Parameters.AddWithValue("@location_description", sample.LocationDescription);

            command.CommandText = "INSERT INTO Samples(name, type, geologic_age, city, location_description" +
                                    "state, country, latitude, longitude, ) VALUES(@name, @type, " +
                                    "@geologic_age, @city, @state, @country, @latitude, @longitude, @location_description);";

            if (command.ExecuteNonQuery() < 1)
                result = false;
            
            return result;
        }



        /*
         * @param Id of sample to be retrieved
         * @return The sample class instance with corresponding ID
         * This method gets a sample by id from the database by assembling all associated images
         * and creating a sample class and returning that class.
         */
        public Sample RetrieveSampleById(int id)
        {
            Sample sample = new Sample();
            MySqlCommand command = new MySqlCommand();
            command.Connection = _conn;
            command.Parameters.AddWithValue("@id", id);

            //Get the sample id, if exists create sample instance and return
            command.CommandText = "SELECT * FROM Samples WHERE sample_id = @id;";
            DataTable data = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
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
            }

            return sample;
        }

        /*
         * @param The id of the issue to be deleted
         * @return True if successful, false if not
         * This method deletes an issue from the database with the passed in id. 
         */
        public bool DeleteIssueById(int id)
        {
            MySqlCommand command = _conn.CreateCommand();
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
         * @param Id of sample to be deleted
         * @return True if delete successful, false if not
         * This deletes a sample in the database with the matching sample id passed
         * in by the user. 
         */
        public bool DeleteSampleById(int id)
        {
            MySqlCommand command = _conn.CreateCommand();
            command.Parameters.AddWithValue("@id", id);
            command.CommandText = "DELETE FROM Samples WHERE sample_id = @id;";

            if (command.ExecuteNonQuery() < 1)
            {
                return false;
            }
            else
                return true;
        }

        /*
         * @param Sample that holds the new version of the edited sample.
         * @return True if the row was changed, false if not.
         * This method uses the passed in sample to overwrite the database's
         * version of the sample with the matching sample id. 
         */
        public bool EditSampleById(Sample sample)
        {
            bool result = true;

            //Update sample in db
            MySqlCommand command = _conn.CreateCommand();
            command.Parameters.AddWithValue("@sample_id", sample.Id);
            command.Parameters.AddWithValue("@name", sample.Name);
            command.Parameters.AddWithValue("@type", sample.SampleType);
            command.Parameters.AddWithValue("@geologic_age", sample.GeologicAge);
            command.Parameters.AddWithValue("@city", sample.City);
            command.Parameters.AddWithValue("@state", sample.State);
            command.Parameters.AddWithValue("@country", sample.Country);
            command.Parameters.AddWithValue("@latitude", sample.Latitude);
            command.Parameters.AddWithValue("@longitude", sample.Longtitude);
            command.Parameters.AddWithValue("@location_description", sample.LocationDescription);

            command.CommandText = "UPDATE Samples SET name=@name, type=@type, geologic_age=@geologic_age, " +
                                    "city=@city, state=@state, country=@country, latitude=@latitude, " +
                                    "longitude=@longitude, location_description=@location_description " +
                                    "WHERE sample_id = @sample_id;";

            if (command.ExecuteNonQuery() < 1)
                result = false;

            return result;
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
            command.Connection = _conn;
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
                                            data.Rows[i].Field<int>("issue_type"));
                result.Add(currIssue);
            }

            return result;
        }

        /*
         * @return List of all Sample entries in the database
         * This method queries the database and converts samples from database into 
         * the a List of Sample classes. 
         */
        public List<Sample> RetrieveAllSamples()
        {
            List<Sample> result = new List<Sample>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = _conn;
            command.CommandText = "Select * From Samples;";
            DataTable data = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Sample currSample = new Sample(data.Rows[0].Field<int>("sample_id"),
                                               data.Rows[0].Field<String>("name"),
                                               data.Rows[0].Field<String>("type"),
                                               data.Rows[0].Field<String>("locationDescription"),
                                               data.Rows[0].Field<String>("geologic_age"),
                                               data.Rows[0].Field<String>("city"),
                                               data.Rows[0].Field<String>("state"),
                                               data.Rows[0].Field<String>("country"),
                                               data.Rows[0].Field<Double>("latitude"),
                                               data.Rows[0].Field<Double>("longitude"));
                result.Add(currSample);
            }

            return result;
        }
    }
}