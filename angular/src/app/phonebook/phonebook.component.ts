import { Component, Injector, OnInit, ViewChild } from '@angular/core'; //onIninit not explicitly in apb docs!
import { appModuleAnimation } from 'shared/animations/routerTransition';
import { PersonServiceProxy, PersonListDto, AddPhoneInput, AddPhoneInputType, PhoneInPersonListDtoType } from
    'shared/service-proxies/service-proxies';
import { AppComponentBase } from 'shared/app-component-base';
import { CreatePersonComponent } from 'app/phonebook/create-person/create-person.component';
import { EditPersonComponent } from 'app/phonebook/edit-person/edit-person.component';

/*import { CreatePersonComponent2 } from '@app/phonebook/create-person/create-person2.component';*/

import * as _ from 'lodash';

@Component({
    templateUrl: './phonebook.component.html',
    animations: [appModuleAnimation()]
})
export class PhoneBookComponent extends AppComponentBase implements OnInit {

    @ViewChild('createPersonModal') createPersonModal: CreatePersonComponent;
    @ViewChild('editPersonModal') editPersonModal: EditPersonComponent;

/*    createPersonModal2: CreatePersonComponent2;*/

    people: PersonListDto[] = [];
    filter: string = '';
    isTableLoading: boolean = false;
    editingPerson: PersonListDto = null;
    newPhone: AddPhoneInput = null;

    constructor(
        injector: Injector,
        private _personService: PersonServiceProxy
    ) {
        super(injector);
        console.log(injector);
    }

    ngOnInit(): void {
        //this.testCompVar;
        //this.createPersonModal2;
        this.editPersonModal;
        this.createPersonModal;
        this.getPeople();
    }

    protected getPeople(): void {
        this.isTableLoading = true;
        this._personService.getPeople(this.filter).subscribe((result) => {
            //debugger;
            console.log(result.items);
            this.people = result.items;
            this.isTableLoading = false;
        });
    }

    // Show Modals
    protected createPerson(): void {
        this.createPersonModal.show();
    }

    protected editPerson(personId): void {
        debugger;
        this.editPersonModal.show(personId);
    }

    protected deletePerson(person: PersonListDto): void {
        var fullName = person.name + ' ' + person.surname;
        abp.message.confirm("Delete person '" + fullName + "'?", (result: boolean) => {
                if (result) {
                    this._personService.deletePerson(person.id).subscribe(() => {
                        //abp.notify.info("Deleted User: " + fullName);
                        abp.notify.info(this.l('SuccessfullyDeleted', fullName));

                        this.getPeople();
                    });
                }
            }
        );
    }

    protected editPersonDetails(person: PersonListDto): void {
        if (person === this.editingPerson) {
            this.editingPerson = null;
        }
        else {
            this.editingPerson = person;
            this.newPhone = new AddPhoneInput();
            this.newPhone.type = AddPhoneInputType._0;
            this.newPhone.personId = person.id;

        }
    }

    protected getPhoneTypeAsString(phoneType: PhoneInPersonListDtoType): string {
        switch (phoneType) {
        case PhoneInPersonListDtoType._0:
            return this.l('PhoneType_Mobile');
        case PhoneInPersonListDtoType._1:
            return this.l('PhoneType_Home');
        case PhoneInPersonListDtoType._2:
            return this.l('PhoneType_Business');
        default:
            return'?';
        }
    }

    protected deletePhone(phone, person): void {
        this._personService.deletePhone(phone.id).subscribe(() => {
            this.notify.success(this.l('SuccessfullyDeleted'));
            _.remove(person.phones, phone);
        });
    }

    protected savePhone(): void {
        //debugger;
        if (!this.newPhone.number) {
            this.message.warn('Please enter a number');
            return;
        }

        this._personService.addPhone(this.newPhone).subscribe(result => {
            this.editingPerson.phones.push(result);
            this.newPhone.number = '';
            this.notify.success(this.l('SavedSuccessfully'));
        });
    }

    protected test(): void {
        alert('Ficken');
    }
}

/*weiter mit Creating a Modal
https://aspnetzero.com/Documents/Developing-Step-By-Step-Angular

    add input fields in create - person.component.html as like create- role.component.html*/
