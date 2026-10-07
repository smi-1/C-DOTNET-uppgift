public class Person {
    
    public PersonInfo PersonInfo {get; private set;}
    public AddressInfo AddressInfo {get; private set;}
    public CompanyInfo CompanyInfo {get; private set;}

    public Person(PersonInfo personInfo, AddressInfo addressInfo, CompanyInfo companyInfo) {
        PersonInfo = personInfo;
        AddressInfo = addressInfo;
        CompanyInfo = companyInfo;
    }
}

public class PersonInfo {
    public int IdNumber {get; private set;}
    public string Name {get; private set;}
    public string Email {get; private set;}

    public PersonInfo(int idNumber, string name, string email) {
        IdNumber = idNumber;
        Name = name;
        Email = email;
    }
}

public class AddressInfo {
    public string Street {get; private set;}
    public string City {get; private set;}
    public string PostalCode {get; private set;}

    public AddressInfo(string street, string city, string postalCode) {
        Street = street;
        City = city;
        PostalCode = postalCode;
    }
}

public class CompanyInfo {
    public string Name {get; private set;}
    public string Slogan {get; private set;}
    public CompanyInfo(string name, string slogan) {
        Name = name;
        Slogan = slogan;
    }
}
