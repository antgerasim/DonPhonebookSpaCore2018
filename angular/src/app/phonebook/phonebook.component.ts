import { Component, Injector, OnInit, ViewChild } from '@angular/core';//onIninit not explicitly in apb docs! 
import { AppComponentBase } from 'shared/app-component-base';
import { PersonServiceProxy, PersonListDto, ListResultDtoOfPersonListDto } from 'shared/service-proxies/service-proxies'
import { appModuleAnimation } from 'shared/animations/routerTransition';
import { CreatePersonComponent} from 'app/phonebook/create-person.component';

@Component({
    templateUrl: './phonebook.component.html',
    animations: [appModuleAnimation()]
})

export class PhoneBookComponent extends AppComponentBase implements OnInit  {

    @ViewChild('createPersonModal') createPersonModal: CreatePersonComponent;

    people: PersonListDto[] = [];
    filter: string = '';

    constructor(
        injector: Injector,
        private _personService: PersonServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getPeople();
    }

    getPeople(): void {
        this._personService.getPeople(this.filter).subscribe((result) => {
            //debugger;
            this.people = result.items;
        });
    }
    // Show Modals

    createPerson(): void {
        this.createPersonModal.show();
    }
}


/*weiter mit Creating a Modal
https://aspnetzero.com/Documents/Developing-Step-By-Step-Angular

    add input fields in create - person.component.html as like create- role.component.html*/
