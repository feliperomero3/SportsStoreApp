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
    const supplier = new Supplier(0, 'Splash Dudes', 'San Jose', 'CA');

    service.createSupplier(supplier).subscribe();

    const req = controller.expectOne('api/suppliers');
    expect(req.request.url).toBe('api/suppliers');
    expect(req.request.method).toEqual('POST');
    controller.verify();
  });

  it('should handle a create supplier operation that failed', () => {
    const service: SupplierService = TestBed.get(SupplierService);
    const controller: HttpTestingController = TestBed.get(HttpTestingController);
    const supplier = new Supplier(0, 'Splash Dudes', 'San Jose', 'CA');

    service.createSupplier(supplier).subscribe(
      data => expect(data).toBeUndefined(),
      () => fail('should have handled the failed operation')
    );

    const req = controller.expectOne('api/suppliers');
    req.flush({}, { status: 400, statusText: 'Bad request' });
  });

  it('should replace a supplier', () => {
    const service: SupplierService = TestBed.get(SupplierService);
    const controller: HttpTestingController = TestBed.get(HttpTestingController);
    const supplier = new Supplier(1, 'Splash Dudes', 'San Jose', 'CA');

    service.replaceSupplier(supplier).subscribe(
      data => expect(data).toEqual(supplier, 'should return the replaced supplier'),
      () => fail()
    );

    const req = controller.expectOne('api/suppliers/1');
    expect(req.request.method).toEqual('PUT');
    req.flush(supplier);
    controller.verify();
  });

  it('should delete a supplier', () => {
    const service: SupplierService = TestBed.get(SupplierService);
    const controller: HttpTestingController = TestBed.get(HttpTestingController);
    const supplierId = 1;

    service.deleteSupplier(supplierId).subscribe(
      () => { },
      () => fail()
    );

    const req = controller.expectOne('api/suppliers/1');
    expect(req.request.method).toEqual('DELETE');
    controller.verify();
  });

});
