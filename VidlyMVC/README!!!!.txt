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

   20 - Create a new action(method) inside of Customers Controller called New.

   21 - Create a view for this action. Empty view.

   22 - Don't forget, we are using HTML Helpers methods, and LINQ Methods.

   23 - When we use the "using", it will do the dispose, it will do the dispose the HTML tag too.

   24 - We have 2 ways to change the Birthdate name to Date of Birth. One:
    * Is in the Customer class inside Models folder, put an DataAnnotation.
   Second:
    * Is to put an HTML label element.

   25 - Next we will create a drop-down list.

   26 - Add in IdentityModels class inside Models folder, the DbSet for membershipTypes. In DbContext method.

   27 - Create a variabel of type var to put the list of membershipTypes.

   28 - Create a ViewModel called(NewCustomerViewModel) in ViewModels folder.

   29 - Rearrange the View accordingly.

   30 - Create a new action(method) called Create in Customers controller.

   31 - Create a button Save in View.

   32 - Add in action(method) the add, save and the RedirectAction.

   33 - In view Index of Customers, we are gonna change the ActionLink from Details to Edit.

   34 - Next create an new method(action) called Editin Customers controller.

   35 - Change the name of the viewModel from the NewCustomerViewModel to CustomerFormViewModel.

   36 - Change the view name form New to CustomerForm. Don't forget to change in the beginning the part of the model 
   to @model VidlyMVC.ViewModels.CustomerFormViewModel.

   37 - Change the place of the checkBox to the bottom, before the button, in the view CustomerForm.

   38 - We will change the method(action) form Create to Save, this method is in controller Customers. And we have to 
   change the parameter of BeginForm from "Create" to "Save" in view CustomerForm.

   39 - This method Save will check if contains an id or not. If don't have an id add a new customer, if have an id do
   an update to that customer.

   40 - We have to add an input hidden field to id in the view CustomerForm, to method save check the id.  

   //================================= Exercise 4 - Do the part to create a new movie and edit a movie:
   41 - Create a new movie and edit a movie:
    * Do this into a few parts, instead os doing all in one go.
    * Create a viewModel for the moview.
    * In movie controller add some methods, New, Edit and Save.
    * Add a button in the begin of the Index view of movies. This button is a link to create a new movie.
    * Change the link from Details to Edit.
    * The form to create and edit is the same.
    * When is to create will appear New Movie, when is to edit will appear Edit Movie.
    * The form to create or edit have to have 4 fields, Name, Release Date, Genre(DropDown List) and Number in Stock.
    Don't forget, the hidden field to id.
   //========================================================================================

   42 - Troubleshooting Entity Validation Errors:
    * In this case, we either place a try/catch block, or change the required for the GenreId property. As the 
	Entity Framework understands that it is the same as the Genre navigation property, we do not need to create a
	new migration.







