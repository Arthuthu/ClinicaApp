﻿namespace ClinicaRepository.SqlDataAccess
{
	public interface ISqlDataAccess
	{
		Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "ClinicaConnection");
		Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "ClinicaConnection");
	}
}