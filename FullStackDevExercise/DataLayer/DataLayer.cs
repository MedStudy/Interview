using FullStackDevExercise.Entities;
using FullStackDevExercise.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Data
{
  public class DataLayer
  {
    public List<Owner> GetOwners(int id)
    {
      string query = $@"
      SELECT Id, FirstName, LastName
      FROM owners";
      if (id != 0)
      {
        query += $@" where Id = {id}";
      }
      SQLiteHelper sQLiteHelper = new SQLiteHelper();
      List<Owner> owners = SQLiteHelper.Query<Owner>(query);
      return owners;
    }

    public int AddUpdateOwner(Owner owner)
    {
      string query;
      if (owner.Id == 0)
      {
        query = $@"
          INSERT INTO owners(FirstName, LastName) values('{owner.FirstName}','{owner.LastName}');
          SELECT last_insert_rowid();";
      }
      else
      {
        query = $@"
          UPDATE owners SET FirstName = '{owner.FirstName}' , LastName = '{owner.LastName}'
          WHERE Id = {owner.Id};
          SELECT {owner.Id}";
      }
      SQLiteHelper sQLiteHelper = new SQLiteHelper();
      var id = Convert.ToInt32(SQLiteHelper.ExecuteScalar(query));
      return id;
    }
    public List<Pet> GetPets(int id)
    {
      string query = $@"
      SELECT Id, OwnerId, Name, Type, Age
      FROM pets";
      if (id != 0)
      {
        query += $@" where Id = {id}";
      }
      SQLiteHelper sQLiteHelper = new SQLiteHelper();
      List<Pet> pets = SQLiteHelper.Query<Pet>(query);
      return pets;
    }

    public int AddUpdatePet(Pet pet)
    {
      string query;
      if (pet.Id == 0)
      {
        query = $@"
          INSERT INTO pets(OwnerId, name, type, age) values('{pet.OwnerId}','{pet.Name}', '{pet.Type}', {pet.Age});
          SELECT last_insert_rowid();";
      }
      else
      {
        query = $@"
          UPDATE pets SET name = '{pet.Name}' , type = '{pet.Type}', age = {pet.Age}
          WHERE Id = {pet.Id};
          SELECT {pet.Id}";
      }
      SQLiteHelper sQLiteHelper = new SQLiteHelper();
      int id = Convert.ToInt32(SQLiteHelper.ExecuteScalar(query));
      return id;
    }

    public List<Appointment> GetAppointments(int id)
    {
      string query = $@"
      SELECT appointments.Id, appointments.OwnerId, appointments.PetId,
      owners.FirstName , owners.LastName,
      pets.Name as PetName, pets.Type, pets.Age,
      appointments.AppointmentDate, appointments.IsComplete
      FROM appointments
      INNER JOIN owners ON owners.Id = appointments.OwnerId
      INNER JOIN pets ON pets.Id = appointments.PetId";
      if (id != 0)
      {
        query += $@" where appointments.id = {id}";
      }
      SQLiteHelper sQLiteHelper = new SQLiteHelper();
      List<AppointmentSnapshot> appointmentsnaps = SQLiteHelper.Query<AppointmentSnapshot>(query);
      List<Appointment> appointments = new List<Appointment>();
      appointmentsnaps.ForEach(x => {
        Appointment appointment = new Appointment();
        appointment.Id = x.Id;
        appointment.AppointmentDate = x.AppointmentDate;
        appointment.IsComplete = x.IsComplete;
        appointment.owner = new Owner();
        appointment.owner.Id = x.OwnerId;
        appointment.owner.FirstName = x.FirstName;
        appointment.owner.LastName = x.LastName;
        appointment.pet = new Pet();
        appointment.pet.Id = x.PetId;
        appointment.pet.OwnerId = x.OwnerId;
        appointment.pet.Name = x.PetName;
        appointment.pet.Type = x.Type;
        appointment.pet.Age = x.Age;
        appointments.Add(appointment);
      });
      return appointments;
    }

    public int AddAppointment (Appointment appointment)
    {
      string query;
      if (appointment.Id == 0)
      {
        query = $@"
          INSERT INTO appointments(OwnerId, PetId, AppointmentDate, IsComplete) values({appointment.owner.Id},{appointment.pet.Id}, '{appointment.AppointmentDate}', 0);
          SELECT last_insert_rowid();";
      }
      else
      {
        query = $@"
          UPDATE appointments SET AppointmentDate = '{appointment.AppointmentDate}'
          WHERE Id = {appointment.Id};
          SELECT {appointment.Id}";
      }
      SQLiteHelper sQLiteHelper = new SQLiteHelper();
      int id = Convert.ToInt32(SQLiteHelper.ExecuteScalar(query));
      return id;
    }

    public int DeletePet(int id)
    {
      string query = $@"DELETE FROM pets WHERE Id = {id};";
      SQLiteHelper sQLiteHelper = new SQLiteHelper();
      SQLiteHelper.ExecuteNonQuery(query);
      return 1;
    }

    public int DeleteOwner(int id)
    {
      string query = $@"DELETE FROM owners WHERE Id = {id};";
      SQLiteHelper sQLiteHelper = new SQLiteHelper();
      SQLiteHelper.ExecuteNonQuery(query);
      return 1;
    }

    public int DeleteAppointment(int id)
    {
      string query = $@"DELETE FROM appointments WHERE Id = {id};";
      SQLiteHelper sQLiteHelper = new SQLiteHelper();
      SQLiteHelper.ExecuteNonQuery(query);
      return 1;
    }
    public int MarkCompleteAppointment(int id)
    {
      string query = $@"
          UPDATE appointments SET IsComplete = 1
          WHERE Id = {id};";
      SQLiteHelper sQLiteHelper = new SQLiteHelper();
      SQLiteHelper.ExecuteNonQuery(query);
      return 1;
    }
  }
}
