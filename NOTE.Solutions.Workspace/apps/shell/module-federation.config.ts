import type { ModuleFederationConfig } from '@nx/module-federation';

// const sharedPackages: Record<string, string> = {
//   '@angular/core': '21.0.0',
//   '@angular/common': '21.0.0',
//   '@angular/common/http': '21.0.0',
//   '@angular/router': '21.0.0',
//   'rxjs': '7.8.0',
// };

const config: ModuleFederationConfig = {
  name: 'systemAdmin',

  exposes: {
    './Module': 'apps/systemAdmin/src/app/remote-entry/entry-module.ts',
  },

  // disableNxRuntimeLibraryControlPlugin: true,

  // shared: (name) => {
  //   if (sharedPackages[name]) {
  //     return {
  //       singleton: true,
  //       strictVersion: true,
  //       requiredVersion: sharedPackages[name],
  //     };
  //   }
  //   return undefined;
  // },


};

export default config;
