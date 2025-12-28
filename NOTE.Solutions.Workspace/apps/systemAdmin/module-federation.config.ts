import type { ModuleFederationConfig } from '@nx/module-federation';

const config: ModuleFederationConfig = {
  name: 'systemAdmin',

  exposes: {
    './Module': 'apps/systemAdmin/src/app/remote-entry/entry-module.ts',
  },

};

export default config;
