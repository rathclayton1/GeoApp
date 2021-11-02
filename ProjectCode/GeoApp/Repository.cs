using System;
using System.Collections.Generic;
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
        }

        public bool AddNewSample(Sample sample)
        {
            Boolean result = true;
            MySqlCommand command = conn.CreateCommand();
            int test = sample.Id;
            command.Parameters.AddWithValue("@clue", sample.Id);

            command.CommandText = "INSERT INTO Samples(sample_id, name, type, geologic_age, city, " +
                                    "state, country, latitude, longitude) VALUES(@sample_id, @name, @type, " +
                                    "@geolic_age, @city, @state, @country, @latitude, @longitude)";

            if (command.ExecuteNonQuery() < 1)
            {
                result = false;
            }

            return result;
        }

        public bool DeleteIssueById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSampleById(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditSampleById(Sample sample)
        {
            throw new NotImplementedException();
        }

        public List<Issue> RetrieveAllIssues()
        {
            throw new NotImplementedException();
        }

        public List<Sample> RetrieveAllSamples()
        {
            return new List<Sample>();
        }

        public Sample RetrieveSampleById(int id)
        {
            return new Sample();
        }
    }
}