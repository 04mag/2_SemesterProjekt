using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using System.Text.Json;

IAnsatService ansatService = new AnsatService(new AnsatRepository());

List<Mekaniker>? ansatte = ansatService.ReadMekanikere();

string jsonString = JsonSerializer.Serialize(ansatte);

Console.WriteLine(jsonString);