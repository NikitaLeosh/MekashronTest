# MekashronTest
###
This is the test case for Mekashron. It represents a single-page bootstrap site which contains log-in form.
###
The task involves connecting a remote service and using its login function. In case of a successful login, a green success message and entity details are displayed on the screen. In case of an error, a red error message is shown with the details of the error.<br>
As for a single-page site it was prefferable to use razor-pages template adding the link to the remote service via WCF.<br>
For faster page load Response Compression is used along with JS script postponing the load of linked code documents. Critical css code is placed to _Layout.<br>
This site is deployed. Please feel free to check it out via this [link](https://mekashrontest.herokuapp.com/)<br>
Test on PageSpeed Insights is passed with 100/100 result both for computer and mobile gadgets. 
