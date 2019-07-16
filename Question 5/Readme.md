Question 5
Our oil and gas client would like an application to track the depletion of their 5 sites. Each site
has between 2 and 5 wells and each well extracts oil, natural gas, or a combination of the two.
There are many large pieces of equipment that need to be assigned to each well including
things like extractors, storage tanks, office buildings, etc. Each well has been analyzed by oil
and gas engineers and they can determine the reserves before any drilling starts. Each day the
equipment operates, the natural resources are extracted and sent to be refined. Our client will
provide the data similar to the tables below.

Solution Abstract: I decided to use plotly to plot the graphs.  I did a little bit of googling and landed on it and it
seemed easy enough to use.  I originally had the extraction data and initial site data in two separate json files, 
but didn't want the hassle of using jQuery or Node to read/import the files.  Even exporting them as modules 
seemed to cause a rather small headache that I did not want to deal with.  I wanted a concise solution without too much baggage,
also I wanted to submit this as soon as possible, so I kinda cheated and just put the data in two objects (pretending I already received the data from some axios call).
Afterwhich, I was able to abstract out some functions that extract the data how we need it for the graph. 