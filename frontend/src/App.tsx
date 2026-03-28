import React, { useState } from 'react';
import { ActionPanel, LogPanel } from './components';
import { Action, LogEntry } from './types';
import './App.css';

const mockActions: Action[] = [
  { id: 1, name: 'Подключиться' },
  { id: 2, name: 'Отключиться' },
  { id: 3, name: 'Отправить данные' },
  { id: 4, name: 'Обновить статус' },
  { id: 5, name: 'Очистить логи' },
];

const mockLogs: LogEntry[] = [
  { id: 1, objectName: 'Hub', eventName: 'Connected', eventData: 'Connection ID: abc123' },
  { id: 2, objectName: 'User', eventName: 'Login', eventData: 'user@example.com' },
  { id: 3, objectName: 'Order', eventName: 'Created', eventData: 'Order #1001' },
  { id: 4, objectName: 'Hub', eventName: 'Message', eventData: 'Hello World' },
  { id: 5, objectName: 'System', eventName: 'Error', eventData: 'Timeout exception' },
];

function App() {
  const [logs, setLogs] = useState<LogEntry[]>(mockLogs);

  const handleAction = (action: Action) => {
    if (action.name === 'Очистить логи') {
      setLogs([]);
    } else {
      const newLog: LogEntry = {
        id: Date.now(),
        objectName: 'Action',
        eventName: action.name,
        eventData: `Выполнено в ${new Date().toLocaleTimeString()}`,
      };
      setLogs((prev) => [...prev, newLog]);
    }
  };

  return (
    <div className="flex h-screen w-screen bg-gray-100">
      <ActionPanel actions={mockActions} onActionClick={handleAction} />
      <LogPanel logs={logs} onClearLogs={() => setLogs([])} />
    </div>
  );
}

export default App;
