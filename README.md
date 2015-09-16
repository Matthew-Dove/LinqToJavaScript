# Linq () => JavaScript


### What is it?
A small project, with a few examples of turning LINQ expressions into JavaScript functions.


### Example
    var sum = _dynamicService.CreateFunction<int, int, int>((a, b) => a + b);  
    var script = _dynamicService.CreateScript(() => sum, () => divide);  

Outputs:  

    function sum(a, b) {
        return a + b;
    }


### Remarks
This isn't a production ready project, just an experiment.


This software is released under the [MIT License](http://opensource.org/licenses/MIT).