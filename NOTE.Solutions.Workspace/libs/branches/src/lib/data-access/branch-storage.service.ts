import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { BranchResponse } from "../models/responses/branch-response";
import { STORAGE_KEY_CONSTS } from '@app/shared/constants';

@Injectable({ providedIn: 'root' })
export class BranchStorageService {

  private branchSubject = new BehaviorSubject<number | null>(null);

  constructor() {
    this.load();
  }

  private load() {
    const stored = localStorage.getItem(
      STORAGE_KEY_CONSTS.AUTH.CURRENT_BRANCH
    );

    if (stored) {
      try {
        this.branchSubject.next(+stored);
      } catch {
        this.clear();
      }
    }
  }

  save(branchId: number) {
    localStorage.setItem(
      STORAGE_KEY_CONSTS.AUTH.CURRENT_BRANCH,
      branchId.toString()
    );
    this.branchSubject.next(branchId);
  }

  clear() {
    localStorage.removeItem(STORAGE_KEY_CONSTS.AUTH.CURRENT_BRANCH);
    this.branchSubject.next(null);
  }

  get value(): number | null {
    return this.branchSubject.value;
  }

  get value$(): Observable<number | null> {
    return this.branchSubject.asObservable();
  }
}
