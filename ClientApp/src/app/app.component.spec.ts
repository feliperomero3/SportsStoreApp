import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { of } from 'rxjs';
import { AppComponent } from './app.component';
import { ProductService } from './product.service';
import { SupplierService } from './supplier.service';

describe('AppComponent', () => {
  let mockProductService: any;
  const mockSupplierService: any = {};

  beforeEach(async(() => {
    mockProductService = jasmine.createSpyObj(['getProduct', 'getProducts']);
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        AppComponent
      ],
      providers: [
        { provide: ProductService, useValue: mockProductService },
        { provide: SupplierService, useValue: mockSupplierService }
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
    mockProductService.getProducts.and.returnValue(of([]));

    fixture.detectChanges();

    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('Products Catalog');
  });

  it('can retrieve a product', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const product = { name: 'Kayak', category: 'Water sports', price: '276' };
    mockProductService.getProduct.and.returnValue(of(product));

    fixture.componentInstance.getProduct(1);

    expect(fixture.componentInstance.product).toBeTruthy();
  });

  it('can retrieve multiple products', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const products = [
      { name: 'Kayak', category: 'Water sports', price: '276' },
      { name: 'Lifejacket', category: 'Water sports', price: '49.95' }
    ];
    mockProductService.getProducts.and.returnValue(of(products));

    fixture.componentInstance.getProducts();

    expect(fixture.componentInstance.products.length).toBe(2);
  });
});
