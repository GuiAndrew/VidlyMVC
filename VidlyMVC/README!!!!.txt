1 - We create some classes in Models folder to do the Customer, Movie and the MembershipType.

2 - We create the controllers Customers and Movies. This is to create the object customer and the object movie.

3 - In the controller Customers we create a method that create a "hardcoded" customers, this is only to see how this methods
works and they pass information to the views.

4 - We did this in the movies controller too.

5 - And we create views to see this in action. But before we tested some methods without views.

6 - We have create a folder ViewModels, with a class call RandomMovieViewModel.

7 - We create migrations.

8 - To enable migration, Command -> Enable-Migrations.

9 - To add one migrations, Command -> Add-Migration NameOfThisMigration.

10 - To update and execute the migration, Command -> Update-Migration.

11 - If we want to recreate the migration we the same name was before, Command -> Add-Migration NameOfThisMigration -Force.
(Will overwrite the last migration).

12 - To seed the database, we create a empty migration and use the Sql method.

13 - Migration aren't case sensitive.

14 - In the view Index of Customers add a new <th> for discount rate and a new <td> to get the discount rate.

15 - If we run the code now will give a NullReferenceException. So we have to related the customer and membershipType together, 
this is call Eager Loading. In the Customerscontroller before the ToList() method, we have to add the Include method with the 
Lampda, to call the MembershipType. In the top of the class put using System.Data.Entity. The full line:
var customers = _context.Customers.Include(c => c.MembershipType).ToList();

16 - Now we will create a shortcut to package manager console. So we go to Tools -> Options -> In Environment, 
select Keyboard -> In the TextBox Show commands containning, enter packagemanagerconsole, all together. -> In TextBox Press
Shortcut Keys put the keys that will be the shortcut. In this case i chose alt + /. -> Next click Assing -> next Ok.
NOTE: Be careful not to overlap with shorcut that are already created.

//================================= Exercise 1 - Add membership type to list of customers:
17 - Add membership type to list of customers:
 * First we alter the classe MembershipType, and add the Name property;
 * Next create an migration to add this property;
 * Next we update this migration;
 * To add some seed to this column Name in the MembershipType, we add one empty migration, and do the seed in the 
 Sql method.
 * Next update this migration.
 * Last we alter the view to add the Name of the MembershipType.
 //========================================================================================

 //================================= Exercise 2 - Add birthdate to customer:
 18 - Add birthdate to customer:
  * First Add a property Birthdate to Customer. To accept null add ? to the property.
  * Create an migration to add this property. Do the update too.
  * Next Add a condition to the view Details of Customer, to see if the birthdate has value. If not, if is null, 
  will not appear.
  //========================================================================================

  //================================= Exercise 3 - Display the list of movies and their details:
  19 - Display the list of movies and their details:
   * First we add the DbSet for Movie in class ApplicationDbContext.
   * Add class Movie to Models folder. 
   * Add properties to Movies class, and Genre class.
   * Every properties off Movies are Required.
   * Populate table Movies with movies.
   * The table Genre will contains referenced data, so we have to populate this table with the Sql method, in
   an empty migration. Similar to what we do with MembershipType.
   * Next we have to modify the MoviesController e Views(Index and Details) properly.
   * When we click in one movie will appear the details.
   //========================================================================================

   20 - 
