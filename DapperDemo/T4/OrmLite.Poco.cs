
// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `connstring`
//     Provider:               `Npgsql`
//     Connection String:      `Server=127.0.0.1;Database=dvdrental;User Id=postgres;password=**zapped**;`
//     Schema:                 ``
//     Include Views:          `False`

//     Factory Name:          `NpgsqlFactory`
// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DapperDemo
{
	
    public partial class Staff 
    {
    
		[Key]
        public int staff_id { get; set;}
        [Required]
        public string first_name { get; set;}
        [Required]
        public string last_name { get; set;}
        [Required]
        public short address_id { get; set;}
        public string email { get; set;}
        [Required]
        public short store_id { get; set;}
        [Required]
        public bool active { get; set;}
        [Required]
        public string username { get; set;}
        public string password { get; set;}
        [Required]
        public DateTime last_update { get; set;}
        public string picture { get; set;}
    }
	
    public partial class Inventory 
    {
    
		[Key]
        public int inventory_id { get; set;}
        [Required]
        public short film_id { get; set;}
        [Required]
        public short store_id { get; set;}
        [Required]
        public DateTime last_update { get; set;}
    }
	
    public partial class Country 
    {
    
		[Key]
        public int country_id { get; set;}
        [Required]
        public string country { get; set;}
        [Required]
        public DateTime last_update { get; set;}
    }
	
    public partial class Store 
    {
    
		[Key]
        public int store_id { get; set;}
        [Required]
        public short manager_staff_id { get; set;}
        [Required]
        public short address_id { get; set;}
        [Required]
        public DateTime last_update { get; set;}
    }
	
    public partial class Language 
    {
    
		[Key]
        public int language_id { get; set;}
        [Required]
        public string name { get; set;}
        [Required]
        public DateTime last_update { get; set;}
    }
	
    public partial class Actor 
    {
    
		[Key]
        public int actor_id { get; set;}
        [Required]
        public string first_name { get; set;}
        [Required]
        public string last_name { get; set;}
        [Required]
        public DateTime last_update { get; set;}
    }
	
    public partial class City 
    {
    
		[Key]
        public int city_id { get; set;}
        [Required]
        public string city { get; set;}
        [Required]
        public short country_id { get; set;}
        [Required]
        public DateTime last_update { get; set;}
    }
	
    public partial class Film 
    {
    
		[Key]
        public int film_id { get; set;}
        [Required]
        public string title { get; set;}
        public string description { get; set;}
        public int? release_year { get; set;}
        [Required]
        public short language_id { get; set;}
        [Required]
        public short rental_duration { get; set;}
        [Required]
        public decimal rental_rate { get; set;}
        public short? length { get; set;}
        [Required]
        public decimal replacement_cost { get; set;}
        public string rating { get; set;}
        [Required]
        public DateTime last_update { get; set;}
        public string special_features { get; set;}
        [Required]
        public string fulltext { get; set;}
    }
	
    public partial class Film_actor 
    {
        [Required]
        public short actor_id { get; set;}
        [Required]
        public short film_id { get; set;}
        [Required]
        public DateTime last_update { get; set;}
    }
	
    public partial class Category 
    {
    
		[Key]
        public int category_id { get; set;}
        [Required]
        public string name { get; set;}
        [Required]
        public DateTime last_update { get; set;}
    }
	
    public partial class Rental 
    {
    
		[Key]
        public int rental_id { get; set;}
        [Required]
        public DateTime rental_date { get; set;}
        [Required]
        public int inventory_id { get; set;}
        [Required]
        public short customer_id { get; set;}
        public DateTime? return_date { get; set;}
        [Required]
        public short staff_id { get; set;}
        [Required]
        public DateTime last_update { get; set;}
    }
	
    public partial class Film_category 
    {
        [Required]
        public short film_id { get; set;}
        [Required]
        public short category_id { get; set;}
        [Required]
        public DateTime last_update { get; set;}
    }
	
    public partial class Address 
    {
    
		[Key]
        public int address_id { get; set;}
        [Required]
        public string address { get; set;}
        public string address2 { get; set;}
        [Required]
        public string district { get; set;}
        [Required]
        public short city_id { get; set;}
        public string postal_code { get; set;}
        [Required]
        public string phone { get; set;}
        [Required]
        public DateTime last_update { get; set;}
    }
	
    public partial class Customer 
    {
    
		[Key]
        public int customer_id { get; set;}
        [Required]
        public short store_id { get; set;}
        [Required]
        public string first_name { get; set;}
        [Required]
        public string last_name { get; set;}
        public string email { get; set;}
        [Required]
        public short address_id { get; set;}
        [Required]
        public bool activebool { get; set;}
        [Required]
        public DateTime create_date { get; set;}
        public DateTime? last_update { get; set;}
        public int? active { get; set;}
    }
	
    public partial class Payment 
    {
    
		[Key]
        public int payment_id { get; set;}
        [Required]
        public short customer_id { get; set;}
        [Required]
        public short staff_id { get; set;}
        [Required]
        public int rental_id { get; set;}
        [Required]
        public decimal amount { get; set;}
        [Required]
        public DateTime payment_date { get; set;}
    }
}
#pragma warning restore 1591


