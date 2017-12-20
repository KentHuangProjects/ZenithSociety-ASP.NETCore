import { Component,OnInit } from '@angular/core';
import {Event} from './event';
import {EventService} from './event.service';
import {ActivityCategory} from './activity-category';
import {EventByWeekService} from './event-by-week.service';
import * as moment from 'moment/moment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[EventService,EventByWeekService]
})
export class AppComponent implements OnInit {
  events: Event[];
  thisevents: Event[];
  myDate: Date;
  eventstoshow: Map<String,Event[]>;

  //button func
  preweek() {
  	//alert("pre");
  	this.weekser.SetPreWeek();
  	 //  	alert(this.weekser.fromDate);
  		// alert(this.weekser.toDate);
	
  	this.thisevents = Array.from(this.weekser.filterEvents(this.events));
  	this.thisevents.sort(this.comparebyd);
 	this.constructEventsMap();
  }
  	//button func
    nextweek() {
  	
  	this.weekser.SetNextWeek();
  	this.thisevents = Array.from(this.weekser.filterEvents(this.events));
  	this.thisevents.sort(this.comparebyd);
 	this.constructEventsMap();
  	//alert(this.thisevents);
  	// alert(this.weekser.fromDate);
  	// alert(this.weekser.toDate);

  }

  constructor(public eventser:EventService, public weekser:EventByWeekService) {
  	this.myDate = new Date();
  }

    getEvents():void {
  	this.eventser.getEvents()
  	.then(es => {this.events = es;
  		for (var i = 0; i < this.events.length; ++i) {
  	  		this.events[i].ef = new Date(this.events[i].eventFromDateTime);
  	  		this.events[i].et = new Date(this.events[i].eventToDateTime);
  	  		this.events[i].theDate = moment(this.events[i].ef).format("dddd, MMMM Do YYYY");
  	  		this.events[i].fromtime = moment(this.events[i].ef).format("h:mm:ss a");
  	  		//console.log(this.events[i].fromtime);
  	  		this.events[i].totime = moment(this.events[i].et).format("h:mm:ss a");
  	  		//console.log(this.events[i].totime);
  	  }		
  		this.weekser.SetupThisweek();
  	this.thisevents = Array.from(this.weekser.filterEvents(this.events));

  	this.thisevents.sort(this.comparebyd);
  	this.eventstoshow = new Map<String, Event[]> ();
  	// for (var i = 0; i < this.thisevents.length; ++i) {
  	// 	if(this.eventstoshow.has(this.thisevents[i].theDate)) {
  	// 		this.eventstoshow.get(this.thisevents[i].theDate).push(this.thisevents[i]);
  	// 	} else {
  	// 		var ess = new Array<Event>();
  	// 		ess.push(this.thisevents[i]);
  	// 		this.eventstoshow.set(this.thisevents[i].theDate,ess);
  	// 	}

  	// }
  	this.constructEventsMap();
  	//console.log(this.eventstoshow);
  		});
  }

  constructEventsMap() {
  	  	this.eventstoshow = new Map<String, Event[]> ();
  	for (var i = 0; i < this.thisevents.length; ++i) {
  		if(this.eventstoshow.has(this.thisevents[i].theDate)) {
  			this.eventstoshow.get(this.thisevents[i].theDate).push(this.thisevents[i]);
  		} else {
  			var ess = new Array<Event>();
  			ess.push(this.thisevents[i]);
  			this.eventstoshow.set(this.thisevents[i].theDate,ess);
  		}

  	}


  }

  comparebyd(a : Event, b : Event) {
  	  if (a.ef < b.ef)
	    return -1;
	  if (a.ef > b.ef)
	    return 1;
	  return 0;

  }




  ngOnInit() {
  	this.getEvents();


  	
  }
  title = 'app';
}
