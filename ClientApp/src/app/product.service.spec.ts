import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ProductService } from './product.service';
import { Product } from './product';
import { Supplier } from './supplier';

describe('ProductService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [
      HttpClientTestingModule
    ],
    providers: [
      ProductService
    ]
  }));

  it('should be created', () => {
    const service: ProductService = TestBed.get(ProductService);
    expect(service).toBeTruthy();
  });

  it('should set the correct URL to get a product', () => {
    const service: ProductService = TestBed.get(ProductService);
    const controller: HttpTestingController = TestBed.get(HttpTestingController);

    service.getProduct(4).subscribe();

    const req = controller.expectOne('api/products/4');
    expect(req.request.url).toBe('api/products/4');
    controller.verify();
  });

  it('should set the correct URL to get products by category', () => {
    const service: ProductService = TestBed.get(ProductService);
    const controller: HttpTestingController = TestBed.get(HttpTestingController);

    service.getProducts('Water sports').subscribe();

    const req = controller.expectOne('api/products?category=Water sports');
    controller.verify();
    expect(req.request.urlWithParams).toBe('api/products?category=Water sports');
  });

  it('should set the correct URL to search for products', () => {
    const service: ProductService = TestBed.get(ProductService);
    const controller: HttpTestingController = TestBed.get(HttpTestingController);

    service.getProducts(null, 'Kayak').subscribe();

    const req = controller.expectOne('api/products?search=Kayak');
    controller.verify();
    expect(req.request.urlWithParams).toBe('api/products?search=Kayak');
  });

  it('should set the correct URL to create a product', () => {
    const service: ProductService = TestBed.get(ProductService);
    const controller: HttpTestingController = TestBed.get(HttpTestingController);
    const supplier = new Supplier(1, 'Splash Dudes', 'San Jose', 'CA');
    const product = new Product(0, 'Splash Snorkel', 'Silicone snorkel with semi-dry top', 'watersports',
      14.49, supplier);

    service.createProduct(product).subscribe();

    const req = controller.expectOne('api/products');
    expect(req.request.url).toBe('api/products');
    controller.verify();
  });
});
