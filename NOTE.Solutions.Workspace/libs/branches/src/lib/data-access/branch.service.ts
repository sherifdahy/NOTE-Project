import { Injectable } from "@angular/core";
import { BranchStorageService } from "./branch-storage.service";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})

export class BranchService {

  constructor(private branchStorage: BranchStorageService) {

  }

  setCurrentBranch(branchId: number) {
    this.branchStorage.save(branchId);
  }

  clearCurrentBranch() {
    this.branchStorage.clear();
  }

  get currentBranch(): number | null {
    return this.branchStorage.value;
  }

  get currentBranch$(): Observable<number | null> {
    return this.branchStorage.value$;
  }
}
