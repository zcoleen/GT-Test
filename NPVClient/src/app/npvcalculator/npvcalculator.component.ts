import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
@Component({
  selector: 'app-npvcalculator',
  templateUrl: './npvcalculator.component.html',
  styleUrls: ['./npvcalculator.component.css']
})
export class NPVcalculatorComponent implements OnInit {

constructor(private http: HttpClient){}

ngOnInit(): void {
  
}

lowerBoundRate = 0;
upperBoundRate = 0;
incrementRate = 0;
cashFlows = '';
NPVList={};
rates =[];

createAuthorizationHeader(headers: Headers) {
  headers.append('Content-Type', 'application/json '); 
}



headers = new Headers({
  "Content-Type": "application/json",
  "Accept": "application/json"
});

calculateNPV()
{

  const headers= new HttpHeaders()
  .set('Content-Type', 'application/json')
  .set('Accept', '*/*')
  .set('Access-Control-Allow-Headers' , 'Content-Type, Authorization');

 this.http.post('http://localhost:5255/api/Calculator/CalculateNPV?lowerBoundRate='
                + this.lowerBoundRate+'&upperBoundRate='
                + this.upperBoundRate+'&incrementRate='
                + this.incrementRate,
                  this.cashFlows.replace(/\s/g,"").split(','),{headers: headers,}).subscribe(response => {
                    this.NPVList = response;
                    this.rates = this.NPVList[0].presentValues.map(item=>item.rate);
                });
}



}
