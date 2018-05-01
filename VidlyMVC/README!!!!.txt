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
	
   43 - Adding Validation:
    -> To use validation in controller, we have to following 3 steps:
	* 1 -> Add data annotations in models classes;
	* 2 -> Use the ModelState.IsValid(if is not valid, return to the same view);
	* 3 -> Use placeholders to show messages to users in the views. This means for example if we are putting a 
	number in a field that only accepts letters, it shows a message indicating that it can only put letters.

	44 - Styling Validation Errors:
	* In the browser, click on the error message with the right mouse button, then select the inspector, check the 
	name of the class of the message, in this case is field-validation-error, and the input too, to make input red
	also, in this case it is input-validation-error.
	* In the css that is inside the Content folder named Site, at the end of the file put the red color for the field
	and the border for input to get the color red also.
	* Put the @Html.ValidationMessageFor into the MembershipTypeId in the view too.
	* Modify the new action(method) in the Customer controller, so that we can do the validations.

	45 - Overwrite the message error:
	* in the the model class, in the Required DataAnnotation add the errorMessage.

	46 - Custom Validation:
	* Create a class named Min18YearsIfAMember that will inherit from the ValidationAttribute that belongs to the
	System.ComponentModel.DataAnnotations. This class will stay in the Models folder.
	* Create a method inside the Min18YearsIfAMember class called ValidationResult IsValid.
	* In the Customer class that is inside the Models folder, in the Birthdate property, call the validation of the 
	Min18YearsIfAMember class.
	* Add in the CustomerForm view the validationMessageFor for the Birthdate.

	47 - Refactoring Magic Numbers:
	* Create two statics read only properties in the MembershipType class.
	* Then in the Min18YearsIfAMember class, replace the 0 and the 1 with the name of the created properties.

	48 - Continua no projecto VidlyMVC:
	* To put the messages at the top all together, we put in the CustomerForm view (in this case) the @Html.ValidationSummary().
	* Do not forget to put Customer = new Customer () (This is to initialize the Customer and thus the customer will have a value 
	and will not give the error) in the New method in the Customers controller. If it will not give Id error is required.
	* We can put true and a sentence as the ValidationSummary parameter. This is personalized.
	* Change the order of the fields, first the ones that appear with error messages and then the ones that do not have error 
	messages.
	* In the browser, in the message of the validationSummary, see the inspect to know what is the class to put this message
	with red too. Change to red in Site.css.

	49 - Client-side Validation:
	* In the view CustomerFrom add the section script.
	* Note: Client side validation, only work with standart data annotations. The class we created will have no effect.

	50 - Anti-forgery Tokens:
	* Anti-forgery token, prevent us from being pirated. This method creates a token, which is like a secret code, and places 
	it as a hidden field in the form, and also places a cookie on the user's PC.
	* Let's put the @Html.AntiForgeryToken () before the button in the CustomerForm view.
	* We also put in the Save method inside the Customers controller, the ValidateAntiForgeryToken.

	51 - Exercise:
	   - implement in the form of view Movies (New) the validations:
	* 1 - Remove the default date 1 Jan 0001.
	* 2 - Stock should also remove 0 which is default. And if put 0 will give validation error, it must be between 1 and 20.
	* 3 - All fields are required. 
	* 4 - And we'll also put the anti-forgery token. We put this near of the button, in view MovieForm.
	* To remove the default date and remove the default stock 0:
	* First is to remove Movie = new Movie () in method New in the Movies controller, within initialization of 
	the MovieFormViewModel.
	* Next we do in the MovieFrom view put @Html.Hidden ("Movie.Id", (Model.Movie! = Null)? Model.Movie.Id: 0) at the bottom, 
	near of the button.
	* Or:
	* create a viewModel. Since it is already created(MovieFormViewModel), we will change this ViewModel. Do not forget to 
	change the view MovieForm to use this ViewModel. In the view do control + H, put .Movie. replace .(dot) and click enter. 
	And we have to do one of two things, either we change the MovieController Edit and Save Methods and we put the properties 
	inside the new MovieFormViewModel, or we create in the ViewModel(MovieFormViewModel) constructors to initialize these 
	properties. And then just pass as a parameter into the new MovieFormViewModel in the Edit and Save methods.




























