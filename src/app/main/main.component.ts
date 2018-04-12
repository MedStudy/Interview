import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

    constructor() { }

    ngOnInit() {

        //get input from text field
        var inputText;

        document.getElementsByClassName('mat-button')[0].onclick = function () { 
            inputText = document.getElementById('input-textbox').value;

            gitHubRequest(inputText);
        };

        
        //perform AJAX API request of username results (returns up to 30)
        function gitHubRequest(username) {
            var request = new XMLHttpRequest();
            request.onload = displayResults;
            request.open('get', 'https://api.github.com/search/users?q=' + username);
            request.send();
        }
        
        //display results - total #, first 10 users (or any if less than 10)
        function displayResults() {
            var responseObj = JSON.parse(this.responseText);
            
            document.getElementById('totalcount-container').innerText = 'total count = ' + responseObj.total_count;
            
            var iMax = responseObj.items.length > 10 ? 10 : responseObj.items.length;
            
            var users = [];
            for (var i = 0; i < iMax; i++) {
                console.log(responseObj.items[i].login);
                if (i == 0) {
                    document.getElementById('users-container').innerHTML = 'First 10 users = <br />';
                }
                document.getElementById('users-container').innerHTML += responseObj.items[i].login + '<br />';
            }
        }
    }

}
