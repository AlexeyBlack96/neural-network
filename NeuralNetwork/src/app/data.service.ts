import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { NeuronModel } from './neuronModel';
 
@Injectable()
export class DataService {
 
    private url = "/api/getNeuronNetwork";
 
    constructor(private http: HttpClient) {}
 
    getNewNeuron() {
        return this.http.get(this.url);
    }

}