import { ModuleFederationConfig } from '@nx/module-federation';

const config: ModuleFederationConfig = {
  name: 'client',
  exposes: {
    './Module': 'apps/client/src/app/remote-entry/entry-module.ts',
  },
};

export default config;
