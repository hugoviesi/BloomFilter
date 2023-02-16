using BloomFilter;

//Essa declaração do filter poderia estar no método construtor de uma classe Service, por exemplo...

var hashFunction = HashFunctions.FromType<string>();
var capacity = 100000000;
var _filter = new BloomFilter<string>(capacity, 0.01F, hashFunction, hashFunction);

//Os emails muito provavelmente já estariam sido adicionados na base de dados pensando um fluxo completo

AddEmail("hugo@email.com");
AddEmail("thomeo@email.com");
AddEmail("viesi@email.com");

//Valor do input de um cadastro, por exemplo, para verificar se já existe na base de dados ou não

var input = "hugo@email.com";

//Resposta da consulta pelo BloomFilter, poderia ser usado posteriormente para andamento do fluxo, como uma Exception, Alert, Notification...

var response = EmailExists(input) ? "Contém" : "Não contém";

Console.WriteLine($"BloomFilter: {response}");

Console.ReadKey();

bool EmailExists(string email)
{
    return _filter.MaybeContains(email);
}

void AddEmail(string email)
{
    //Add email in filter
    _filter.Add(email);

    //Add email in repository
    //await _repository.Add(email);
}