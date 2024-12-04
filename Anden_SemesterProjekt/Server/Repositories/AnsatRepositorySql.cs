using Anden_SemesterProjekt.Shared.Models;
using Microsoft.Data.SqlClient;
using System;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class AnsatRepositorySql : IAnsatRepository
    {
        private string connectionString;

        public AnsatRepositorySql()
        {
            this.connectionString = "Server=LocalHost;Database=SlDatabase;Trusted_Connection=True;Trust Server Certificate=True";
        }

        public async Task<Mekaniker?> ReadMekaniker(int id)
        {
            Mekaniker mekaniker = new Mekaniker();

            string sqlCommand = "SELECT * FROM Mekanikere WHERE MekanikerId = @Id";

            using SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(sqlCommand, connection);

            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                connection.Open();

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    //Update to fit model
                    mekaniker = new Mekaniker() { MekanikerId = (int)reader["MekanikerId"], Navn = (string)reader["Navn"], ErAktiv = (bool)reader["ErAktiv"] };

                    List<Mærke>? mekanikerMærker = await GetMærker(mekaniker.MekanikerId);

                    if (mekanikerMærker != null)
                    {
                        mekaniker.Mærker = mekanikerMærker;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

            return mekaniker;
        }

        public async Task<List<Mekaniker>?> ReadMekanikere()
        {
            List<Mekaniker> mekanikerList = new List<Mekaniker>();

            string sqlCommand = "SELECT * FROM Mekanikere";

            using SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(sqlCommand, connection);

            try
            {
                connection.Open();

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Mekaniker mekaniker = new Mekaniker() { MekanikerId = (int)reader["MekanikerId"], Navn = (string)reader["Navn"], ErAktiv = (bool)reader["ErAktiv"] };

                    List<Mærke>? mekanikerMærker = await GetMærker(mekaniker.MekanikerId);

                    if (mekanikerMærker != null)
                    {
                        mekaniker.Mærker = mekanikerMærker;
                    }

                    mekanikerList.Add(mekaniker);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

            return mekanikerList;
        }

        public async Task<List<Mærke>?> GetMærker(int mekanikerId)
        {
            List<Mærke> mærkerList = new List<Mærke>();

            string sqlCommand = "SELECT m.MærkeId, m.ScooterMærke FROM Mærker m JOIN MekanikerMærke mm ON m.MærkeId = mm.MærkeId WHERE mm.MekanikerId = @Id";

            using SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(sqlCommand, connection);

            cmd.Parameters.AddWithValue("@Id", mekanikerId);

            try
            {
                connection.Open();

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Mærke Mærke = new Mærke() { MærkeId = (int)reader["MærkeId"], ScooterMærke = (string)reader["ScooterMærke"] };

                    mærkerList.Add(Mærke);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

            return mærkerList;
        }
    }
}
