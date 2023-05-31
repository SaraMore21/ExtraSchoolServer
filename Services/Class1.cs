using System;
using AutoMapper;

namespace Services
{


    //public class Role
    //{
    //    public string Name { get; set; }
    //}

    //public class User
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }

    //    public byte Age { get; set; }

    //    public Role Role { get; set; }
    //}

    //public class UserModel
    //{
    //    public string Name { get; set; }

    //    public byte Age1 { get; set; }

    //    public string RoleName { get; set; }
    //}


    //public class Program
    //{
    //    public static void Main()
    //    {
    //        Mapper.CreateMap<User, UserModel>()
    //            .ForMember(m => m.Name, opt => opt.ResolveUsing(e => e.FirstName + " " + e.LastName))
    //            .ForMember(m => m.Age1, opt => opt.MapFrom(e => e.Age))
    //            .ForMember(m => m.RoleName, opt => opt.MapFrom(e => e.Role.Name))
    //            .ReverseMap();
    //        //.ForMember(m => m.FirstName, opt => opt.ResolveUsing(e => e.Name.Split(' ')[0]))
    //        //.ForMember(m => m.LastName, opt => opt.ResolveUsing(e => e.Name.Split(' ')[1]))
    //        //.ForMember(m => m.Age, opt => opt.MapFrom(e => e.Age1))
    //        //.ForMember(m => m.Role, opt => opt.ResolveUsing(e => new Role {Name = e.RoleName}));

    //        Console.WriteLine("Straight Mapping");

    //        var user = new User
    //        {
    //            FirstName = "Sergey",
    //            LastName = "Guryev",
    //            Age = 28,
    //            Role = new Role { Name = "CoWorker" }
    //        };

    //        var userModel = Mapper.Map<UserModel>(user);

    //        Console.WriteLine(userModel.Name);
    //        Console.WriteLine(userModel.Age1);
    //        Console.WriteLine(userModel.RoleName);

    //        Console.WriteLine("Reverse Mapping");

    //        var userReverse = Mapper.Map<User>(userModel);

    //        Console.WriteLine(userReverse.FirstName);
    //        Console.WriteLine(userReverse.LastName);
    //        Console.WriteLine(userReverse.Age);
    //        Console.WriteLine(userReverse.Role != null ? userReverse.Role.Name : "ERROR");
    //    }
    //}
}
