import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { PersonServiceProxy, CreatePersonInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
    selector: 'create-person-modal',
    templateUrl: './create-person.component.html'
})
export class CreatePersonComponent extends AppComponentBase {
    @ViewChild('createPersonModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    active: boolean = false;
    saving: boolean = false;

    person: CreatePersonInput = null;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    constructor(
        injector: Injector,
        private _personService: PersonServiceProxy
    ) {
        super(injector);
    }

    show(): void {
        this.active = true;
        this.person = new CreatePersonInput();
        this.modal.show();
        //this.modal.show({ class: 'modal-lg'});
    }

    onShown(): void {
        // $(this.modalContent.nativeElement).focus();
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }
    save(): void {
        this.saving = true;
        this._personService.createPerson(this.person)
            .finally(() => { this.saving = false; })
            .subscribe(() => {
                //debugger;
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(this.person);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
