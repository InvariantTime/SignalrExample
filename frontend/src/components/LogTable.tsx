import React from 'react';
import { LogEntry } from '../types';

interface LogTableProps {
  logs: LogEntry[];
}

export function LogTable({ logs }: LogTableProps) {
  return (
    <div className="bg-white rounded-lg shadow overflow-hidden">
      <table className="w-full">
        <thead className="bg-gray-50">
          <tr>
            <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
              Название объекта
            </th>
            <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
              Название события
            </th>
            <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
              Данные события
            </th>
          </tr>
        </thead>
        <tbody>
          {logs.map((log) => (
            <tr key={log.id} className="hover:bg-gray-50">
              <td className="px-4 py-3 text-sm text-gray-900">{log.objectName}</td>
              <td className="px-4 py-3 text-sm text-gray-900">{log.eventName}</td>
              <td className="px-4 py-3 text-sm text-gray-600">{log.eventData}</td>
            </tr>
          ))}
          {logs.length === 0 && (
            <tr>
              <td colSpan={3} className="px-4 py-8 text-center text-gray-500">
                Логи пусты
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}
