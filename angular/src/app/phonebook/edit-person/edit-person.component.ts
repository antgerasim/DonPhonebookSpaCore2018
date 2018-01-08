import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { PersonServiceProxy, EditPersonInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
    selector: 'edit-person-modal',
    templateUrl: './edit-person.component.html'
})
export class EditPersonComponent extends AppComponentBase {

    //in templateUrl <div bsModal #editPersonModal="bs-modal" class="modal fade"
    @ViewChild('editPersonModal') modal: ModalDirective;
    //in templateUrl <div #modalContent class="modal-content">
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;

    person: EditPersonInput = null;

    constructor(
        injector: Injector,
        private _personService: PersonServiceProxy
    ) {
        super(injector);
    }

    show(id: number): void {
      
        this._personService.getPersonForEdit(id).subscribe((result) => {
            this.person = result;
            this.active = true;
            this.modal.show();

        });
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    save(): void {
        this._personService.editPerson(this.person)
            .subscribe(() => {
                this.saving = true;
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(this.person);
                this.saving = false;
            });

    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }

}
