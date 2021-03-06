﻿using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;
using NpgsqlTypes;

namespace GD.Data.Access.Repositories
{
	public class EntityContactRepository : IEntityContactRepository
	{
		private IDataAccessContext DbContext { get; }

		public EntityContactRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(EntityContact model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fentitycontact_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(EntityContact model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fentitycontact_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<EntityContact> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<EntityContact>>(@"rtsurvey.fentitycontact_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public EntityContact GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<EntityContact>>(@"rtsurvey.fentitycontact_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public IEnumerable<EntityContact> GetByClient<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<EntityContact>>(@"rtsurvey.fentitycontactbyidclient_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			});
		}

		public bool Exists<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

	}
}