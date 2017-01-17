using Dapper;
using Framework.Core.Contracts.Data;
using Framework.Core.ViewModels;
using Framework.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data
{
    public class PersonData : BaseData, IPersonData
    {
        private List<PersonViewModel> _people;
                
        public List<PersonViewModel> GetAll()
        {
            if (_people == null)
            {
                try
                {
                    using (Database = Connect)
                    {
                        _people = (List<PersonViewModel>)Database.Query<PersonViewModel>(DbScripts.People.Sql.GetAll);
                    }
                }
                catch (Exception ex)
                {
                    _people = null;
                }
            }

            return _people;
        }

        public void Save(PersonViewModel person)
        {
            try
            {
                var sql = (person.ID > 0) ? DbScripts.People.Sql.Update : DbScripts.People.Sql.Insert;
                var paramters = ParametersBuilder.Build(DbScripts.People.Parameters.Id, person.ID)
                    .WithParameter(DbScripts.People.Parameters.FirstName, person.FirstName)
                    .WithParameter(DbScripts.People.Parameters.LastName, person.LastName)
                    .WithParameter(DbScripts.People.Parameters.Height, person.Height)
                    .WithParameter(DbScripts.People.Parameters.Weight, person.Weight)
                    .WithParameter(DbScripts.People.Parameters.Age, person.Age);
                
                using (Database = Connect)
                {
                    int id = Database.Query<int>(sql, paramters).Single();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM [dbo].[People] WHERE Id=@id";
            using (Database = Connect)
            {
                int result = Database.Query<int>(sql, id).Single();
            }
        }
        
        public PersonViewModel GetById(int id)
        {
            if (id > 0)
            {
                try
                {
                    using (Database = Connect)
                    {
                        var paramters = ParametersBuilder.Build(DbScripts.People.Parameters.Id, id);
                        return Database.Query<PersonViewModel>(DbScripts.People.Sql.GetById, paramters).SingleOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    return new PersonViewModel();
                }
            }

            return new PersonViewModel();                                    
        }

        public List<PersonViewModel> GetByFirstName(string first)
        {
            if (!string.IsNullOrEmpty(first))
            {
                try
                {
                    using (Database = Connect)
                    {
                        var paramters = ParametersBuilder.Build(DbScripts.People.Parameters.FirstName, first);
                        return (List<PersonViewModel>)Database.Query<PersonViewModel>(DbScripts.People.Sql.GetByFirstName, paramters);
                    }
                }
                catch (Exception ex)
                {
                    return new List<PersonViewModel>();
                }
            }

            return new List<PersonViewModel>();                            
        }

        public List<PersonViewModel> GetByLastName(string last)
        {
            if (!string.IsNullOrEmpty(last))
            {
                try
                {
                    using (Database = Connect)
                    {
                        var paramters = ParametersBuilder.Build(DbScripts.People.Parameters.LastName, last);
                        return (List<PersonViewModel>)Database.Query<PersonViewModel>(DbScripts.People.Sql.GetByLastName, paramters);
                    }
                }
                catch (Exception ex)
                {
                    return new List<PersonViewModel>();
                }
            }

            return new List<PersonViewModel>();
        }
    }
}