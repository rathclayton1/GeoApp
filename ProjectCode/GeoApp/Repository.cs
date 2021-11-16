using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace GeoApp
{
    public class Repository : IRepository
    {
        List<Sample> _dataList = new();
        MySqlConnection _conn = new();

        public Repository(MySqlConnection conn) 
        {
            _conn = conn;
            _dataList = RetrieveAllSamples();
        }

        /// <summary>
        /// This method sends this sample to the database to be added with image. 
        /// This assumes we know the sample id, need to next implement it without id created.
        /// </summary>
        /// <param name="sample">Sample to be added</param>
        /// <returns>True if successful, false if not</returns>
        public bool AddNewSample(Sample sample)
        {
            //Send sample to db
            MySqlCommand command = _conn.CreateCommand();
            command.Connection = _conn;

            command.Parameters.AddWithValue("@sample_id", sample.SampleId);
            command.Parameters.AddWithValue("@name", sample.Name);
            command.Parameters.AddWithValue("@type", sample.SampleType);
            command.Parameters.AddWithValue("@geologic_age", sample.GeologicAge);
            command.Parameters.AddWithValue("@location_description", sample.LocationDescription);
            command.Parameters.AddWithValue("@city", sample.City);
            command.Parameters.AddWithValue("@state", sample.State);
            command.Parameters.AddWithValue("@country", sample.Country);
            command.Parameters.AddWithValue("@latitude", sample.Latitude);
            command.Parameters.AddWithValue("@longitude", sample.Longitude);

            command.CommandText = "INSERT INTO Samples(sample_id, name, type, geologic_age, location_description," +
                                    " city, state, country, latitude, longitude) " +
                                   "VALUES(@sample_id, @name, @type, @geologic_age, @location_description, @city, @state, @country, " +
                                    "@latitude, @longitude)";

            if (command.ExecuteNonQuery() < 1)
                return false;
            
            return true;
        }

        /// <summary>
        /// This method gets a sample by id from the database by assembling all associated images
        /// and creating a sample class and returning that class.
        /// </summary>
        /// <param name="id">Id of sample to be retrieved</param>
        /// <returns>The sample class instance with corresponding Id</returns>
        public Sample RetrieveSampleById(int id)
        {
            Sample sample = new Sample();
            MySqlCommand command = new MySqlCommand();
            command.Connection = _conn;
            command.Parameters.AddWithValue("@id", id);

            //Get the sample id, if exists create sample instance and return
            command.CommandText = "SELECT * " +
                                  "FROM Samples " +
                                  "WHERE sample_id = @id";
            DataTable data = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(data);

            if (data != null)
            {
                sample.SampleId = data.Rows[0].Field<int>("sample_id");
                sample.Name = data.Rows[0].Field<String>("name");
                sample.SampleType = data.Rows[0].Field<String>("type");
                sample.GeologicAge = data.Rows[0].Field<String>("geologic_age");
                sample.City = data.Rows[0].Field<String>("city");
                sample.State = data.Rows[0].Field<String>("state");
                sample.Country = data.Rows[0].Field<String>("country");
                sample.Latitude = data.Rows[0].Field<Double>("latitude");
                sample.Longitude = data.Rows[0].Field<Double>("longitude");
            }

            return sample;
        }

        /// <summary>
        /// This deletes a sample in the database with the matching sample id passed 
        /// in by the user. 
        /// </summary>
        /// <param name="id">Id of sample to be deleted</param>
        /// <returns>True if delete successful, false if not</returns>
        public bool DeleteSampleById(int id)
        {
            MySqlCommand command = _conn.CreateCommand();
            command.Parameters.AddWithValue("@id", id);
            command.CommandText = "DELETE FROM Samples " +
                                  "WHERE sample_id = @id";

            if (command.ExecuteNonQuery() < 1)
                return false;
            
            return true;
        }

        /// <summary>
        /// This method uses the passed in sample to overwrite the database's
        /// version of the sample with the matching sample id. 
        /// </summary>
        /// <param name="sample">Sample that holds the new version of the edited sample.</param>
        /// <returns>True if the row was changed, false if not.</returns>
        public bool EditSampleById(Sample sample)
        {
            //Update sample in db
            MySqlCommand command = _conn.CreateCommand();
            command.Parameters.AddWithValue("@sample_id", sample.SampleId);
            command.Parameters.AddWithValue("@name", sample.Name);
            command.Parameters.AddWithValue("@type", sample.SampleType);
            command.Parameters.AddWithValue("@geologic_age", sample.GeologicAge);
            command.Parameters.AddWithValue("@city", sample.City);
            command.Parameters.AddWithValue("@state", sample.State);
            command.Parameters.AddWithValue("@country", sample.Country);
            command.Parameters.AddWithValue("@latitude", sample.Latitude);
            command.Parameters.AddWithValue("@longitude", sample.Longitude);

            command.CommandText = "UPDATE Samples " +
                                  "SET name=@name, type=@type, geologic_age=@geologic_age, city=@city, state=@state, " +
                                    "country=@country, latitude=@latitude, longitude=@longitude" +
                                  "WHERE sample_id = @sample_id";

            if (command.ExecuteNonQuery() < 1)
                return false;

            return true;
        }

        /// <summary>
        /// This method queries the database and converts samples from database into
        /// the a List of Sample classes.
        /// </summary>
        /// <returns>List of all Sample entries in the database</returns>
        public List<Sample> RetrieveAllSamples()
        {
            List<Sample> result = new List<Sample>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = _conn;
            command.CommandText = "Select * " +
                                  "From Samples";
            DataTable data = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Sample sample = new Sample();
                sample.SampleId = data.Rows[i].Field<int>("sample_id");
                sample.Name = data.Rows[i].Field<String>("name");
                sample.SampleType = data.Rows[i].Field<String>("type");
                sample.GeologicAge = data.Rows[i].Field<String>("geologic_age");
                sample.City = data.Rows[i].Field<String>("city");
                sample.State = data.Rows[i].Field<String>("state");
                sample.Country = data.Rows[i].Field<String>("country");
                sample.Latitude = data.Rows[i].Field<Double>("latitude");
                sample.Longitude = data.Rows[i].Field<Double>("longitude");
                sample.LocationDescription = data.Rows[i].Field<String>("location_description");

                result.Add(sample);
            }

            return result;
        }

        /// <summary>
        /// This method adds an issue to the database. 
        /// </summary>
        /// <param name="issue">Issue to be added to the database.</param>
        /// <returns>True if database was changed, else false.</returns>
        public bool CreateIssue(Issue issue)
        {
            MySqlCommand command = _conn.CreateCommand();
            command.Parameters.AddWithValue("@type", issue.Type);
            command.Parameters.AddWithValue("@issue_description", issue.IssueDescription);
            command.Parameters.AddWithValue("@date_submitted", issue.DateTimeSubmitted);
            command.Parameters.AddWithValue("@resolved", issue.Resolved);

            command.CommandText = "INSERT INTO Issue(description, date, issue_type, resolved)" +
                                  "VALUES(@issue_description, @date_submitted, @type, @resolved)";

            if (command.ExecuteNonQuery() < 1)
                return false;

            return true;
        }

        /// <summary>
        /// This method gets issues from the database and converts them into
        /// a list of returned issues.
        /// </summary>
        /// <returns>List of all issues, empty list if no issues in DB</returns>
        public List<Issue> RetrieveAllIssues()
        {
            List<Issue> result = new List<Issue>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = _conn;
            command.CommandText = "Select * " +
                                  "From Issues";
            DataTable data = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Issue issue = new Issue();
                issue.referenceId = data.Rows[i].Field<int>("issue_id");
                issue.IssueDescription = data.Rows[i].Field<String>("description");
                issue.DateTimeSubmitted = data.Rows[i].Field<DateTime>("date");
                issue.Type = data.Rows[i].Field<int>("issue_type") == 0 ?
                    Issue.IssueType.Misinformation : Issue.IssueType.SystemIssue;
                /* TO DO:
                 * resolved boolean needs to be got from the database */
                result.Add(issue);
            }

            return result;
        }

        /// <summary>
        /// This method deletes an issue from the database with the passed in id. 
        /// </summary>
        /// <param name="id">The id of the issue to be deleted</param>
        /// <returns>True if successful, false if not</returns>
        public bool DeleteIssueById(int id)
        {
            MySqlCommand command = _conn.CreateCommand();
            command.Parameters.AddWithValue("@id", id);

            command.CommandText = "DELETE FROM Issues " +
                                  "WHERE issue_id = @id";

            if (command.ExecuteNonQuery() < 1)
                return false;

            return true;
        }
    }
}