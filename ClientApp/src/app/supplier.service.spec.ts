import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { SupplierService } from './supplier.service';
import { Supplier } from './supplier';

describe('SupplierService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [
      HttpClientTestingModule
    ],
    providers: [
      SupplierService
    ]
  }));

  it('should be created', () => {
    const service: SupplierService = TestBed.get(SupplierService);
    expect(service).toBeTruthy();
  });

  it('should set the correct URL to create a supplier', () => {
    const service: SupplierService = TestBed.get(SupplierService);
    const controller: HttpTestingController = TestBed.get(HttpTestingController);
    const supplier = new Supplier(1, 'Splash Dudes', 'San Jose', 'CA');

    service.createSupplier(supplier).subscribe();

    const req = controller.expectOne('api/suppliers');
    expect(req.request.url).toBe('api/suppliers');
    controller.verify();
  });
});
