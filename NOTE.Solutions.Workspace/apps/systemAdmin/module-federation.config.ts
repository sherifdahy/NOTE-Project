import type { ModuleFederationConfig } from '@nx/module-federation';

const config: ModuleFederationConfig = {
  name: 'systemAdmin',
  exposes: {
    './Module': 'apps/systemAdmin/src/app/remote-entry/entry-module.ts',
  },
  shared: (name, config) => {
    const sharedLibraries : { [key: string]: string } = {
      '@angular/core': '21.0.6',
      '@angular/common': '21.0.6',
      '@angular/common/http': '21.0.6',
      '@angular/router': '21.0.6',
      'rxjs': '7.8.2'
    };

    if (name in sharedLibraries) {
      return {
        singleton: true,
        strictVersion: false,
        requiredVersion: sharedLibraries[name]
      };
    }
    return config;
  },
};

export default config;
