export interface PermissionItem {
  key: string;
  label: string;
  value: string;
}

export interface PermissionGroup {
  key: string;
  label: string;
  permissions: PermissionItem[];
}

export const PERMISSIONS: PermissionGroup[] = [
  {
    key: 'branches',
    label: 'Branches',
    permissions: [
      { key: 'read', label: 'Read Branches', value: 'branches:read' },
      { key: 'create', label: 'Create Branches', value: 'branches:create' },
      { key: 'update', label: 'Update Branches', value: 'branches:update' },
      { key: 'toggleStatus', label: 'Enable / Disable Branches', value: 'branches:toggleStatus' }
    ]
  },
  {
    key: 'activeCodes',
    label: 'Active Codes',
    permissions: [
      { key: 'read', label: 'Read Active Codes', value: 'activeCodes:read' },
      { key: 'create', label: 'Create Active Codes', value: 'activeCodes:create' },
      { key: 'update', label: 'Update Active Codes', value: 'activeCodes:update' },
      { key: 'toggleStatus', label: 'Enable / Disable Active Codes', value: 'activeCodes:toggleStatus' }
    ]
  },
  {
    key: 'counties',
    label: 'Counties',
    permissions: [
      { key: 'read', label: 'Read Counties', value: 'counties:read' },
      { key: 'create', label: 'Create Counties', value: 'counties:create' },
      { key: 'update', label: 'Update Counties', value: 'counties:update' },
      { key: 'toggleStatus', label: 'Enable / Disable Counties', value: 'counties:toggleStatus' }
    ]
  },
  {
    key: 'governorates',
    label: 'Governorates',
    permissions: [
      { key: 'read', label: 'Read Governorates', value: 'governorates:read' },
      { key: 'create', label: 'Create Governorates', value: 'governorates:create' },
      { key: 'update', label: 'Update Governorates', value: 'governorates:update' },
      { key: 'toggleStatus', label: 'Enable / Disable Governorates', value: 'governorates:toggleStatus' }
    ]
  },
  {
    key: 'cities',
    label: 'Cities',
    permissions: [
      { key: 'read', label: 'Read Cities', value: 'cities:read' },
      { key: 'create', label: 'Create Cities', value: 'cities:create' },
      { key: 'update', label: 'Update Cities', value: 'cities:update' },
      { key: 'toggleStatus', label: 'Enable / Disable Cities', value: 'cities:toggleStatus' }
    ]
  },
  {
    key: 'permissions',
    label: 'Permissions',
    permissions: [
      { key: 'read', label: 'Read Permissions', value: 'permissions:read' }
    ]
  },
  {
    key: 'roles',
    label: 'Roles',
    permissions: [
      { key: 'read', label: 'Read Roles', value: 'roles:read' },
      { key: 'create', label: 'Create Roles', value: 'roles:create' },
      { key: 'update', label: 'Update Roles', value: 'roles:update' },
      { key: 'toggleStatus', label: 'Enable / Disable Roles', value: 'roles:toggleStatus' }
    ]
  },
  {
    key: 'pointOfSales',
    label: 'Point of Sales',
    permissions: [
      { key: 'read', label: 'Read Point of Sales', value: 'pointOfSales:read' },
      { key: 'create', label: 'Create Point of Sales', value: 'pointOfSales:create' },
      { key: 'update', label: 'Update Point of Sales', value: 'pointOfSales:update' },
      { key: 'toggleStatus', label: 'Enable / Disable Point of Sales', value: 'pointOfSales:toggleStatus' }
    ]
  }
];
