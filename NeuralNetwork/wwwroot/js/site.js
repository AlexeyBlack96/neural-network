$(document).ready(function () {

    function loadChart (count, data,data1){

        var ctx = document.getElementById('Errors').getContext('2d');
        var chart = new Chart(ctx, {
    // The type of chart we want to create
            type: 'line',

            // The data for our dataset
            data: {
                labels: count,
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: data,
                    fill: false,
                    pointRadius: 0,
                    borderWidth: 0
                },{
                    label: "My Second Dataset",
                    backgroundColor: 'rgb(0, 88, 255)',
                    borderColor: 'rgb(0, 88, 255)',
                    data: data1,
                    fill: false,
                    pointRadius: 0,
                    borderWidth: 0
                }]
            },

            // Configuration options go here
            options: {
                responsive: true,
                title: {
                    display: true,
                    text: 'Chart.js Line Chart'
                },
                tooltips: {
                    mode: 'index',
                    intersect: false,
                },
                hover: {
                    mode: 'nearest',
                    intersect: true
                },
                scales: {
                    xAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Month'
                        }
                    }],
                    yAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Value'
                        }
                    }]
                }
            }
        });
    }

    function getError(){
let result = [];
            let count = [];
            let a = 0;
let result1 = [];
            let count1 = [];
            let a1 = 0
        $.ajax({
          url: '/Neuron/get',
          success: function(data){

            for(let item = 0; item < data.errors.length; item++){
                console.log(data.errors.length);
                for(let jitem = 1; jitem < data.errors[item].errorsInOne.length; jitem+=jitem*5){
                    console.log(data.errors[item].errorsInOne.length);
                    a++;
                    result.push(data.errors[item].errorsInOne[jitem]);
                    count.push(a);
                    
                    }
                }
            $.ajax({
          url: '/Neuron/getget',
          success: function(data){

            for(let item = 0; item < data.errors.length; item++){
                console.log(data.errors.length);
                for(let jitem = 1; jitem < data.errors[item].errorsInOne.length; jitem+=jitem*5){
                    console.log(data.errors[item].errorsInOne.length);
                    a1++;
                    result1.push(data.errors[item].errorsInOne[jitem]);
                    count1.push(a);
                    
                }
            }
            loadChart (count, result,result1);
          }
        });
          }
        });

        //getNeuron(data.perceptrons);

    }

    $(document).on("click", "#Reteach", function(){
        getError();
    });



function getNeuron(data){
    var canvas = new draw2d.Canvas("gfx_holder");
    var start = [];
    var end = [];
    var c = [];
    console.log(data);

         var LabelConnection= draw2d.Connection.extend({
            init:function(attr, name)
            {
              this._super(attr);
            
              // Create any Draw2D figure as decoration for the connection
              //
                this.setRouter(null);
             
             
              this.attr({
                    radius:100,
                  outlineColor:"#777777",
                  color:"#777777"
              });
            }
        });
        for(var i = 0; i < data.neuron.length; i++){
            start.push( new draw2d.shape.node.Start({x:50, y:i*120}));
            start[i].add(new draw2d.shape.basic.Label({text:`${data.neuron[i].in}`}), new draw2d.layout.locator.CenterLocator());

            canvas.add(start[i]);
            for(var j = 0; j < data.neuron[i].weights.length; j++){
                if(i === 0){
                    end.push(new draw2d.shape.node.End({width:150, height:50}));
                    c.push(new LabelConnection({
                         source:start[i].getOutputPort(0),
                         target:end[j].getInputPort(0)
                     }, `${data.neuron[i].weights[j].weights}`));
                    end[j].add(new draw2d.shape.basic.Label({
                    text:`${data.neuron[i].weights[j].out}`}), 
                    new draw2d.layout.locator.CenterLocator()

                    );
                     canvas.add(end[j],350, j*100);

                }
                else{
                    c.push(new LabelConnection({
                         source:start[i].getOutputPort(0),
                         target:end[j].getInputPort(0)
                     }, `${data.neuron[i].weights[j].weights}`));
                }

            }

        }
        for(var i = 0; i < c.length; i++){
             canvas.add(c[i]);
        }


    };






    getError();
});




