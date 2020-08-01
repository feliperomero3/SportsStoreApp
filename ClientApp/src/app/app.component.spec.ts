import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { ProductService } from './product.service';
import { of } from 'rxjs';

describe('AppComponent', () => {
  let mockProductService: any;

  beforeEach(async(() => {
    mockProductService = jasmine.createSpyObj(['getProducts']);
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        AppComponent
      ],
      providers: [
        { provide: ProductService, useValue: mockProductService }
      ]
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it('should have as title \'Products Catalog\'', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('Products Catalog');
  });

  it('should render title \'Products Catalog\'', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const product = [{ name: 'Kayak', category: 'Water sports', price: '276' }];
    mockProductService.getProducts.and.returnValue(of(product));

    fixture.detectChanges();

    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('Products Catalog');
  });
});
