# TEST AUTOMATION FRAMEWORK ON EVENTURES WEB APP

# Eventures Web App

The Web app holds a list of **events**, created by different **users** (after register / login).

### Users
 - Users can **register** on the site with their own provided username, email, password, first name and last name.
 - Users can **login** by username + password.
 - After either **register / login** users can **view** existing events, **edit** / **delete** owned events and **create** new events.

### Events
Each **event** has a name, place, start date, end date, total tickets, price per ticket and owner.
The **event owner** is the user who created a certain event.
 - Anyone can view all events but editing and deleting events is limited to their respective owners.
 - By requirement, the event owner **can edit and delete his own events** but **cannot edit and delete other user's events**.

# Eventures Web App Test Automation Framework

Eventures Web Application ([Click](http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:81/)) is provided by Software University (SoftUni) for educational purposes.

The framework is build with C#, Selenium WebDriver, NUnit, Page Object Model Design Pattern and Page Factory.

Every time a test failure occurs, a screenshot gets saved in a 'Screenshots' folder.

The automated tests check the functionality of the following features of the application:

 - **Register** - Users can register on the site with their own provided username, email, password, first name and last name.
 - **Login** - Users can login by username and password.
 - **Home page** -  After either a successful registration or successful login, users are taken to the Home page.
 - **Create new event** - Logged in users can create new events.
 - **View all events** - Users can view all existing events but can edit and delete only events that they created.
 - **Edit event** - Logged in user can edit the name, place, start date, end date, total tickets and price per ticket for his own events.
 - **Delete event** - From the All events page, logged in user can delete his own events.
