import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { By } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { TodoListItemComponent } from './todolist-item.component';
import { FormsModule } from '@angular/forms';

let httpClientSpy: { get: jasmine.Spy };

describe('TodoListItemComponent (e2e)', () => {
    let fixture;
    let getElement;

    beforeEach(async(() => {
        httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
        TestBed.configureTestingModule({
            imports: [
                RouterTestingModule,
                FormsModule
            ],
            declarations: [
                TodoListItemComponent,
            ],
            providers: [
                { provide: HttpClient, use: httpClientSpy }
            ]
        }).compileComponents();

        fixture = TestBed.createComponent(TodoListItemComponent);
        getElement = (name:string) => fixture.debugElement.query(By.css(name));
    }));

    it('exists', () => {
        const app = fixture.debugElement.componentInstance;
        expect(app).toBeTruthy();
    });

    it('display readonly description', () => {
        // Act
        fixture.componentInstance.item = { id: "123", description: "call my dad" };
        fixture.detectChanges();

        // Assert
        expect(getElement('span')).toBeTruthy();
        expect(getElement('input')).toBeFalsy();
    });

    it('set description editable on click', () => {
        // Arrange
        fixture.componentInstance.item = { id: "123", description: "call my dad" };
        fixture.detectChanges();

        // Act
        var span = getElement('span');
        span.triggerEventHandler('click', null);
        fixture.detectChanges();

        // Assert
        expect(getElement('span')).toBeFalsy();
        expect(getElement('input')).toBeTruthy();
    });

    it('cancel description edition on escape', () => {
        // Arrange
        fixture.componentInstance.item = { id: "123", description: "call my dad" };
        fixture.componentInstance.edit();
        fixture.detectChanges();

        // Act
        var span = getElement('input');
        span.triggerEventHandler('keyup.escape', null);
        fixture.detectChanges();

        // Assert
        expect(getElement('span')).toBeTruthy();
        expect(getElement('input')).toBeFalsy();
    });
});