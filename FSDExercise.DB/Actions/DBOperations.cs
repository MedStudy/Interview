using Dapper;
using FSDExercise.DB.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSDExercise.DB.Actions
{
  public class DBOperations : IDBOperations
  {
    private readonly IConfiguration _configuration;
    private readonly string _dbName;
    public DBOperations(IConfiguration configuration)
    {
      _configuration = configuration;
      _dbName = _configuration.GetConnectionString("interviewdb");
    }

    public async Task DeleteOwner(Owner owner)
    {
      var deleteQuery = $"DELETE FROM owners WHERE id =@id";
      using (var connection = new SqliteConnection(_dbName))
      {
        await connection.ExecuteAsync(deleteQuery, owner);
      }
    }

    public async Task<Pet> GetPetAsync(int id)
    {
      string query = $"SELECT id, type,name,age,owner_id FROM Pets where id = {id};";
      Pet pet = null;      
      using (var connection = new SqliteConnection(_dbName))
      {

        //await connection.ExecuteAsync("INSERT INTO Product (Name, Description)" +
        //    "VALUES (@Name, @Description);", product);

        //using var connection = new SqliteConnection(databaseConfig.Name);
        
        pet = await connection.QueryFirstAsync<Pet>(query);
      }
      return pet;
    }

    public async Task<IEnumerable<Pet>> GetAllPetsAsync()
    {
      string query = $"SELECT id, type,name,age,owner_id FROM Pets;";
      IEnumerable<Pet> pets = null;
      using (var connection = new SqliteConnection(_dbName))
      {

        //await connection.ExecuteAsync("INSERT INTO Product (Name, Description)" +
        //    "VALUES (@Name, @Description);", product);

        //using var connection = new SqliteConnection(databaseConfig.Name);

        pets = await connection.QueryAsync<Pet>(query);
      }
      return pets;
    }

    public async Task AddPetAsync(Pet pet)
    {      
      using (var connection = new SqliteConnection(_dbName))
      {
        await connection.ExecuteAsync("INSERT INTO Pets(type,name,age,owner_id)" +
            "VALUES (@type,@name,@age,@owner_id);", pet);
      }      
    }

    public async Task UpdatePetAsync(Pet pet)
    {
      var updateQuery = $"UPDATE Pets SET name =@name,age =@age WHERE id =@id";
    
      using (var connection = new SqliteConnection(_dbName))
      {
        await connection.ExecuteAsync(updateQuery, pet);
      }
    }

    public async Task DeletePet(Pet pet)
    {
      var deleteQuery = $"DELETE FROM Pets WHERE id =@id";

      using (var connection = new SqliteConnection(_dbName))
      {
        await connection.ExecuteAsync(deleteQuery, pet);
      }
    }

    #region Appointments
    public async Task AddAppointmentAsync(Appointment appointment)
    {
      using (var connection = new SqliteConnection(_dbName))
      {
        await connection.ExecuteAsync("INSERT INTO appointments(appointee_id,appointmentdate,starttime,endtime,pet_id,status)" +
            "VALUES (@appointee_id,@appointmentdate,@start_time,@end_time,@pet_id,@Status);", appointment);
      }
    }

    public async Task UpdateAppointmentAsync(Appointment appointment)
    {
      var updateQuery = $"UPDATE appointments SET appointmentdate=@appointmentdate,starttime =@start_time,endtime =@end_time WHERE id =@id";

      using (var connection = new SqliteConnection(_dbName))
      {
        await connection.ExecuteAsync(updateQuery, appointment);
      }
    }

    public async Task CancelAppointmentAsync(int appointmentId)
    {
      var Status = "Cancelled";
      var updateQuery = $"UPDATE appointments SET status={Status} WHERE id ={appointmentId}";

      using (var connection = new SqliteConnection(_dbName))
      {
        await connection.ExecuteAsync(updateQuery);
      }
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsByOwnerAsync(int ownerId)
    {
      string query = $"SELECT appointmentdate,starttime,endtime,pet_id,status FROM appointments where appointee_id = {ownerId};";
      IEnumerable<Appointment> appointments = null;
      using (var connection = new SqliteConnection(_dbName))
      {
        appointments = await connection.QueryAsync<Appointment>(query);
      }
      return appointments;
    }

    public async Task<Appointment> GetAppointmentAsync(int appointmentId)
    {
      string query = $"SELECT appointmentdate,starttime,endtime,pet_id,status FROM appointments where id = {appointmentId};";
      Appointment appointment = null;
      using (var connection = new SqliteConnection(_dbName))
      {
        appointment = await connection.QueryFirstAsync<Appointment>(query);
      }
      return appointment;
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByPetAsync(int ownerId,int petId)
    {
      string query = $"SELECT appointmentdate,starttime,endtime,pet_id,status " +
        $"FROM appointments where appointee_id = {ownerId} And pet_id = {petId} ;";

      IEnumerable<Appointment> appointments = null;
      using (var connection = new SqliteConnection(_dbName))
      {
        appointments = await connection.QueryAsync<Appointment>(query);
      }
      return appointments;
    }

    public async Task DeleteAppointment(Appointment appointment)
    {
      var deleteQuery = $"DELETE FROM appointments WHERE id =@id";

      using (var connection = new SqliteConnection(_dbName))
      {
        await connection.ExecuteAsync(deleteQuery, appointment);
      }
    }
    #endregion
  }
}

