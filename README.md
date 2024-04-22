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
