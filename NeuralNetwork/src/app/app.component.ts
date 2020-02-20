import { Component } from '@angular/core';
import { DataService } from './data.service';
import { NeuronModel } from './neuronModel';

@Component({
    selector: 'my-app',
    templateUrl: 'app.template.html',
    styleUrls: ['./app.styles.less'],
    providers: [DataService]
})
export class AppComponent { 
    name= 'Tom';
    neurons: NeuronModel[];

    constructor(private dataService: DataService) { }
 
    ngOnInit() {
        this.loadProducts();// загрузка данных при старте компонента  
    }

    loadProducts() {
        this.dataService.getNewNeuron()
            .subscribe((data: NeuronModel[]) =>
            {
                console.log('qwe', data);
                this.neurons = data
            });

    }
}