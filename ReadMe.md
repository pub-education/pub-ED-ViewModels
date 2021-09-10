# View Models
Add a view to the existing page that displays a list of people. These people should have names, phone numbers and cities. Store this data inside of a model class and send it out to the view as a list. Additionally, there should be two forms attached to this view – one that can filter the list, and one that can add new people to the list.
### Required Features:
* A table of people, generated from a list.
* Two forms:
* One form should filter the table – if you enter a string into the form and submit it, the page should be refreshed and only show the people whose names or cities contain the string you entered.
* The other form should let you add people to the list.
* Each row in the table should show the person, and a link that when clicked, removes the person.
### Code Requirements:
* The table should be displayed using an HTML table generated with C# loop.
* The table data should come from a view model, which should have a list of people, and the search phrase if one exists. The names should be contained in a static list on the class that serves as the data object for each row. Also include methods that handle sorting and filtering to that class.
### Optional:
* Add buttons to sort the list on the page.
* Sort in alphabetical order and reverse alphabetical order, by name and by city.
* Add a checkbox which determines whether the filtering should be case sensitive or not.