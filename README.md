
# world popuation data access

**Clone the repository:**

git clone https://github.com/PujaGhale1/worlddb.git


**change directory**

cd <repo-name >

**Build docker image:**

docker build -t worlddb:latest .


**Compose up docker:**

docker-compose up -d

**Use Case:**

Strictly addressing the identified use case in the population reporting project, it is designed to give the user tools to create extensive and detailed reports on population. This system is ideal for authorities, politicians, city managers and other research institutions involved in analyzing demographic data. When a user enters the system he has an option of picking which type of report he or she would require say by countries or cities or even capital cities in order of population. For example, the user inputs filter criteria such as deciding on which continent to apply the top-populated cities filter or the number of top-populated cities desired. The system then extracts the required data from the lower-level MySQL database, filters the data using fast SQL calls and disseminates the actionable information in a simple, intelligible manner. This makes it possible to view the important populations that will be needed for analysis and planning from a given area in the shortest time possible.

For example, the user could need a list of ten most populated cities in Asia which should be included in the report. The displayed attributes are the following: number of towns 10 and continent Asia After inputting the log in details and proceeding to the right section a value of “10” for the number of towns is entered. When the user starts the generation of the report, the system in turn opens the database, processes data, and then offers to the list of the top 10 cities in Asia, population wise with the actual population size. The user can also see this report on the display and based on the report’s findings, the user may have to download this report in file formats such as pdf or csv for the report be subjected to further analysis and presentation. This features and functionality makes sure that the users are able to easily use the system to learn ideas about the trends and patterns of population in a diverse manner, which enables the making of good decisions and management of resources.

**Use Case Diagram**

![image](https://github.com/PujaGhale1/worlddb/assets/171217357/9732da8f-e94a-4114-bd3f-fa8d3e10618f)


## API Endpoint Documents

Population Summary API
World Population
Endpoint: GET /api/data/population/world


Description: Retrieves the total population of the world.


Response: A decimal number representing the total world population.


Continent Population


Endpoint: GET /api/data/population/continent


Description: Retrieves the total population of a specified continent.


Query Parameter: name (the continent's name)


Response: A decimal number representing the total population of the specified continent.


Region Population


Endpoint: GET /api/data/population/region


Description: Retrieves the total population of a specified region.


Query Parameter: name (the region's name)


Response: A decimal number representing the total population of the specified region.


Country Population


Endpoint: GET /api/data/population/country


Description: Retrieves the total population of a specified country.


Query Parameter: name (the country's name)


Response: A decimal number representing the total population of the specified country.


District Population


Endpoint: GET /api/data/population/district


Description: Retrieves the total population of a specified district.


Query Parameter: name (the district's name)


Response: A decimal number representing the total population of the specified district.


City Population


Endpoint: GET /api/data/population/city


Description: Retrieves the total population of a specified city.


Query Parameter: name (the city's name)


Response: A decimal number representing the total population of the specified city.


Population By Continent


Endpoint: GET /api/data/population/by-continent


Description: Retrieves the population summary grouped by continent.


Response: A list of population summaries, including the population in cities and not in cities for each continent.


Population By Region


Endpoint: GET /api/data/population/by-region


Description: Retrieves the population summary grouped by region.


Response: A list of population summaries, including the population in cities and not in cities for each region.


Population By Country


Endpoint: GET /api/data/population/by-country


Description: Retrieves the population summary grouped by country.


Response: A list of population summaries, including the population in cities and not in cities for each country.


Language Population API


Language Statistics


Endpoint: GET /api/data/language/


Description: Retrieves population statistics for specified languages.


Response: A list of languages with the number of speakers and their percentage of the world population.


Top Populated API


Top Populated Countries


Endpoint: GET /api/top-populated/countries


Description: Retrieves the top populated countries.


Query Parameter: limit (maximum number of countries to return, optional)


Response: A list of the top populated countries with their population numbers.


Top Populated Countries in Continent


Endpoint: GET /api/top-populated/countries-in-continent


Description: Retrieves the top populated countries in a specified continent.


Query Parameters: continent (the continent's name), limit (maximum number of countries to return, optional)


Response: A list of the top populated countries in the specified continent with their population numbers.


Top Populated Countries in Region


Endpoint: GET /api/top-populated/countries-in-region


Description: Retrieves the top populated countries in a specified region.


Query Parameters: region (the region's name), limit (maximum number of countries to return, optional)


Response: A list of the top populated countries in the specified region with their population numbers.


Top Populated Cities


Endpoint: GET /api/top-populated/cities


Description: Retrieves the top populated cities.


Query Parameter: limit (maximum number of cities to return, optional)


Response: A list of the top populated cities with their population numbers.


Top Populated Cities in Continent


Endpoint: GET /api/top-populated/cities-in-continent


Description: Retrieves the top populated cities in a specified continent.


Query Parameters: continent (the continent's name), limit (maximum number of cities to return, optional)


Response: A list of the top populated cities in the specified continent with their population numbers.


Top Populated Cities in Region


Endpoint: GET /api/top-populated/cities-in-region


Description: Retrieves the top populated cities in a specified region.


Query Parameters: region (the region's name), limit (maximum number of cities to return, optional)


Response: A list of the top populated cities in the specified region with their population numbers.


Top Populated Cities in Country


Endpoint: GET /api/top-populated/cities-in-country


Description: Retrieves the top populated cities in a specified country.


Query Parameters: countryCode (the country code), limit (maximum number of cities to return, optional)


Response: A list of the top populated cities in the specified country with their population numbers.


Top Populated Cities in District


Endpoint: GET /api/top-populated/cities-in-district


Description: Retrieves the top populated cities in a specified district.


Query Parameters: district (the district's name), limit (maximum number of cities to return, optional)


Response: A list of the top populated cities in the specified district with their population numbers.


Top Populated Capital Cities


Endpoint: GET /api/top-populated/capital


Description: Retrieves the top populated capital cities.


Query Parameter: limit (maximum number of capital cities to return, optional)


Response: A list of the top populated capital cities with their population numbers.


Top Populated Capital Cities in Continent


Endpoint: GET /api/top-populated/capital-in-continent


Description: Retrieves the top populated capital cities in a specified continent.


Query Parameters: continent (the continent's name), limit (maximum number of capital cities to return, optional)


Response: A list of the top populated capital cities in the specified continent with their population numbers.


Top Populated Capital Cities in Region


Endpoint: GET /api/top-populated/capital-in-region


Description: Retrieves the top populated capital cities in a specified region.


Query Parameters: region (the region's name), limit (maximum number of capital cities to return, optional)


Response: A list of the top populated capital cities in the specified region with their population numbers.



## Contributor Covenant Code of Conduct

We as members, contributors, and leaders pledge to make participation in our
community a harassment-free experience for everyone, regardless of age, body
size, visible or invisible disability, ethnicity, sex characteristics, gender
identity and expression, level of experience, education, socio-economic status,
nationality, personal appearance, race, religion, or sexual identity
and orientation.

# Contribution Guidelines

We welcome contributions of all kinds, including bug reports, new features, documentation improvements, and more. Here’s how you can help:


### Reporting Bugs

* Make sure the issue has not been already reported under issues section in the github. Add comment if found similar.

* If the bug is new then open an issue with descriptive title and details on how to reproduce the bug.


### Suggesting Enhancements

* Search existing issues before suggesting a new feature to avoid duplicates.

* Provide a clear and detailed explanation of the feature you want and why it would be useful.

