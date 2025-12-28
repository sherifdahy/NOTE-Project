import type { ModuleFederationConfig } from '@nx/module-federation';

const config: ModuleFederationConfig = {
  name: 'systemAdmin',
  exposes: {
    './Module': 'apps/systemAdmin/src/app/remote-entry/entry-module.ts',
  },
  disableNxRuntimeLibraryControlPlugin: true,
  shared: (name) => {
    if (
      name === '@angular/core' ||
      name === '@angular/common' ||
      name === '@angular/common/http' ||
      name === '@angular/router' ||
      name === 'rxjs'
    ) {
      return {
        singleton: true,
        strictVersion: true,
        requiredVersion: 'auto',
      };
    }
    return undefined;
  },
};

export default config;
