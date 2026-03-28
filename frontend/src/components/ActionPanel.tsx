import React from 'react';
import { Action } from '../types';

interface ActionPanelProps {
  actions: Action[];
  onActionClick: (action: Action) => void;
}

export function ActionPanel({ actions, onActionClick }: ActionPanelProps) {
  return (
    <div className="w-64 bg-white border-r border-gray-200 p-4 overflow-y-auto">
      <h2 className="text-lg font-semibold mb-4 text-gray-800">Действия</h2>
      <div className="space-y-2">
        {actions.map((action) => (
          <button
            key={action.id}
            onClick={() => onActionClick(action)}
            className="w-full px-4 py-2 text-left bg-blue-500 hover:bg-blue-600 text-white rounded transition-colors"
          >
            {action.name}
          </button>
        ))}
      </div>
    </div>
  );
}
