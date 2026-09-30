public class Person {
    
    public PersonInfo PersonInfo {get;set;}
    public AddressInfo AddressInfo {get;set;}
    public CompanyInfo CompanyInfo {get;set;}

    public Person(PersonInfo personInfo, AddressInfo addressInfo, CompanyInfo companyInfo) {
        PersonInfo = personInfo;
        AddressInfo = addressInfo;
        CompanyInfo = companyInfo;
    }
}

public class PersonInfo {
    public int IdNumber {get;set;}
    public string Name {get;set;}
    public string Email {get;set;}

    public PersonInfo(int idNumber, string name, string email) {
        IdNumber = idNumber;
        Name = name;
        Email = email;
    }
}

public class AddressInfo {
    public string Street {get;set;}
    public string City {get;set;}
    public string PostalCode {get;set;}

    public AddressInfo(string street, string city, string postalCode) {
        Street = street;
        City = city;
        PostalCode = postalCode;
    }
}

public class CompanyInfo {
    public string Name {get;set;}
    public string Slogan {get;set;}
    public CompanyInfo(string name, string slogan) {
        Name = name;
        Slogan = slogan;
    }
}
