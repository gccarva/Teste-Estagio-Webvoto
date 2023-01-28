using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
class token_response{
    public string? acessToken { get; set; }
    public string code { get; set; } = "";
    public string? message { get; set; }
}
class task_response{
    public task? job { get; set; }
    public string code { get; set; } = "";
    public string? message { get; set; }
}
class job_response{
    public string code { get; set; } = "";
    public string? message { get; set; }

}
class task{
    public string id { get; set; } ="";
    public string type { get; set; } = "";
    public string? strand { get; set; }
    public string? strandEncoded { get; set; }
    public string? geneEncoded { get; set; }
}
class Solver_Dna{
    //private string token;
    private const string base_url = "http://localhost:3000"; //"https://gene.lacuna.cc/"
    private string username = "";
    private string password = "";
    private string authtoken = "";
    HttpClient client = new HttpClient();
    public Solver_Dna(){
        this.username = Environment.GetEnvironmentVariable("user") ?? "";
        this.password = Environment.GetEnvironmentVariable("pass") ?? "";
        Console.Write(this.username);
        Console.Write(this.password);
        this.authtoken = get_token().Result;
        Console.Write(this.authtoken);
    }
    async private Task<string> get_token()
    {
        var dict = new Dictionary<string, string>();
        dict.Add("username", username);
        dict.Add("password", password);
        var http = new FormUrlEncodedContent(dict);


        var http_response = await client.PostAsync($"{base_url}/api/users/login", http);
        return await http_response.Content.ReadAsStringAsync();
    }
}
class main{
    public static void Main(){
        var solver = new Solver_Dna();
    }
}