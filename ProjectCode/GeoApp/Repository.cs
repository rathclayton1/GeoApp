using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;


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
            command.Parameters.AddWithValue("@sample_id", sample.Id);
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


            //send images to database |TO BE DONE IN LATER ADD IMAGE SPRINT|
            /*
            if (sample.Images.Count > 0)
                result = AddImagesBySampleId(sample.Images, sample.Id);
            */

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

            //first get all images associated to Sample ID |TO BE DONE IN LATER ADD IMAGE SPRINT|
            /*
            List<List<Byte>> images = GetImagesBySampleId(id);
            */

            //get the sample id, if exists create sample instance and return
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

                /*   |TO BE DONE IN LATER ADD IMAGE SPRINT|
                  if (images.Count != 0)
                     sample.Images = images;
                */
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
            bool result = true;

            //update sample in db
            MySqlCommand command = conn.CreateCommand();
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
                                    "WHERE sample_id = @sample_id";

            if (command.ExecuteNonQuery() < 1)
                result = false;

            /* |TO BE DONE IN LATER ADD IMAGE SPRINT|
                result= UpdateImages(sample);
            */

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
                                            data.Rows[i].Field<int>("issue_type"));
                result.Add(currIssue);
            }

            return result;
        }

        public List<Sample> RetrieveAllSamples()
        {
            List<Sample> result = new List<Sample>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
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


        /* |TO BE DONE IN LATER ADD IMAGE SPRINT|

           public bool UpdateImages(Sample sample)
           {
            //get images associated with sample id
            List<List<Byte>> oldImages = GetImagesBySampleId(sample.Id);
            List<List<Byte>> deleteList = new List<List<Byte>>();
            List<List<Byte>> addList = new List<List<Byte>>();
            //if edited entry doesn't exist in database add to add list
            foreach (List<Byte> currImg in sample.Images)
            {
                if (!oldImages.Contains(currImg))
                {
                    addList.Add(currImg);
                }
            }
            //if old entry doesn't exist in new edited list, add to deleteList
            foreach (List<Byte> currImg in oldImages)
            {
                if (!sample.Images.Contains(currImg))
                {
                    deleteList.Add(currImg);
                }
            }
            //add
            AddImagesBySampleId(addList, sample.Id);
            //delete images

               }


           public bool AddImagesBySampleId(List<List<Byte>> images, int id)
           {
               bool result = true;
               MySqlCommand command = conn.CreateCommand();

               foreach (List<Byte> currList in images)
               {
                   command = conn.CreateCommand();
                   command.Parameters.AddWithValue("@sample_id", id);
                   command.Parameters.AddWithValue("@image", currList);

                   command.CommandText = "INSERT INTO Images(sample_id, image) VALUES (@sample_id, @image);";

                   if (command.ExecuteNonQuery() < 1)
                       result = false;
               }

               return result;
           }

           public bool DeleteImagesBySampleId(int id)
           {
               throw new NotImplementedException();
           }

           public List<List<Byte>> GetImagesBySampleId(int id)
           {
               MySqlCommand command = conn.CreateCommand();
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

               return images;
           }
           */
    }
}