import type { ModuleFederationConfig } from '@nx/module-federation';

const config: ModuleFederationConfig = {
  name: 'systemAdmin',
  exposes: {
    './Module': 'apps/systemAdmin/src/app/remote-entry/entry-module.ts',
  },
  shared: (name, config) => {
    const sharedLibraries = [
      '@angular/core',
      '@angular/common',
      '@angular/common/http',
      '@angular/router',
      'rxjs'
    ];

    if (sharedLibraries.includes(name)) {
      return {
        singleton: true,
        strictVersion: name !== 'rxjs',
        requiredVersion: 'auto',
      };
    }
    return config;
  },
};

export default config;
