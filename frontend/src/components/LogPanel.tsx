import React from 'react';
import { LogEntry } from '../types';
import { LogTable } from './LogTable';

interface LogPanelProps {
  logs: LogEntry[];
  onClearLogs: () => void;
}

export function LogPanel({ logs, onClearLogs }: LogPanelProps) {
  return (
    <div className="flex-1 p-4 overflow-y-auto">
      <div className="flex justify-between items-center mb-4">
        <h2 className="text-lg font-semibold text-gray-800">Логи</h2>
        <button
          onClick={onClearLogs}
          className="px-4 py-2 bg-red-500 hover:bg-red-600 text-white rounded transition-colors"
        >
          Очистить логи
        </button>
      </div>
      <LogTable logs={logs} />
    </div>
  );
}
