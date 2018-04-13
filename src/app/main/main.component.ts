import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    // Note: I know jquery, but don't angular (yet!)... I used the web to figure out how to get jquery code integrated...
    $(document).ready(function(){

      function ClearMessages() {
        $('#errorMessage').hide();
      }

      function ValidateQuery() {
        if ($('#userSearch').val().trim() == "") {
          $('#errorMessage').show().text('^^ Required');
          return false;
        }
        return true;
      }
      
      function displayError(errorThrown) {
        $('#errorMessage').text('Sorry, an error has occurred: ' + errorThrown).show();
      }

      function displayResults(data) {
        var $results = $('#results');
        $results.empty();
        if (data.total_count == 0) {
          displayError('Sorry... no items found.');
          return 0;
        }
        // NOTE: using pagination in URL (see below) to limit result to 10, only displaying first page
        var bFirst = true;
        var strHTMLAppend = '<div class="FiveWideList">';
        data.items.forEach(function (r) {
          if (! bFirst) {
            strHTMLAppend += '<div class="FiveWideSeparator"></div>';
          }
          bFirst = false;
          strHTMLAppend += '<div class="FiveWideItem">';
          strHTMLAppend += '  <a href="' + r.html_url + '" target="_blank" class="FiveWideImage"><img src="' + r.avatar_url + '" alt="' + r.login + '" /></a>';
          strHTMLAppend += '  <a href="' + r.html_url + '" target="_blank" class="name">' + r.login + '</a>';
          strHTMLAppend += '</div>';
        });
        strHTMLAppend += '</div><div class="resultTotal">Total items found: ' + data.total_count + '</div>';
        $results.append(strHTMLAppend);
        return data.total_count;
      }
    
      $('#searchButton').click(function (){
        $('#results').empty();
        ClearMessages();
        if (! ValidateQuery()) {
          return false;
        }
        $('#searchButton').prop('disabled',true);
        $('#results').text('Please wait...');
        $.ajax({
          // https://developer.github.com/v3/guides/traversing-with-pagination/#changing-the-number-of-items-received
          url: 'https://api.github.com/search/users?per_page=10&q=' + encodeURIComponent($('#userSearch').val()),
          'dataType': "json",
          'success': function (data, textStatus, jqXHR) {
            displayResults(data);
          },
          'error': function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR);
            $('#results').empty();
            displayError(errorThrown);
          },
          complete: function () {
            $('#searchButton').prop('disabled',false);
          }
        });
      });

      // click button on enter.. 
      $("#userSearch").keyup(function(event) {
        if (event.keyCode === 13) {
          $("#searchButton").click();
        }
      });
    });
  }
}
